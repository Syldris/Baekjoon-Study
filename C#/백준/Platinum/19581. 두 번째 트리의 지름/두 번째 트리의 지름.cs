#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        List<(int node, int cost)>[] tree = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            tree[i] = new();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            tree[line[0]].Add((line[1], line[2])); // a => b
            tree[line[1]].Add((line[0], line[2])); // b => a
        }

        int[] distA = new int[n + 1]; // 트리의 지름을 이루는 정점 a에서의 거리
        int[] distB = new int[n + 1]; // 정점 b

        DFS(1, -1, distA); // 1번 정점에서 가장 먼 트리의 정점 A 찾기

        int a = 1; 
        int maxDist = 0;

        for (int i = 1; i <= n; i++)
        {
            if (distA[i] > maxDist)
            {
                a = i;
                maxDist = distA[i];
            }
            distA[i] = 0; // a의 기록을 기록해야하니 비워두자.
        }

        DFS(a, -1, distA); // a에서 가장 먼 트리의 정점 b 찾기 + a에서의 모든정점 거리 구해놓기

        maxDist = 0;
        int b = 1;
        for (int i = 1; i <= n; i++)
        {
            if (distA[i] > maxDist)
            {
                b = i;
                maxDist = distA[i];
            }
        }

        DFS(b, -1, distB); // b에서의 거리 한번 재보면 됨.

        maxDist = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i == a || i == b) continue; // 트리의 지름을 이루는 2점은 배제.

            int dist = Math.Max(distA[i], distB[i]); // 2점 중에서 가장 먼 거리를 구하기
            if (dist > maxDist)
                maxDist = dist;
        }

        sw.Write(maxDist);

        void DFS(int node, int parent, int[] dist)
        {
            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;

                dist[child.node] = dist[node] + child.cost;
                DFS(child.node, node, dist);
            }
        }
    }
}