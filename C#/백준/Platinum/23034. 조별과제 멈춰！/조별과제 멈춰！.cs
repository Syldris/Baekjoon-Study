#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1], line[2])); // a => b 
            graph[line[1]].Add((line[0], line[2])); // b => a
        }

        bool[] visited = new bool[n + 1];
        (int node, int cost)[] parent = new (int node, int cost)[n + 1];
        int[] depth = new int[n + 1];
        PriorityQueue<(int node, int cost, int parentNode), int> queue = new();
        queue.Enqueue((1, 0, 0), 0);

        int totalCost = 0;

        while (queue.Count > 0)
        {
            (int node, int cost, int parentNode) = queue.Dequeue();

            if (visited[node]) continue;

            totalCost += cost;
            visited[node] = true;
            parent[node] = (parentNode, cost);
            depth[node] = depth[parentNode] + 1;

            foreach (var next in graph[node])
            {
                if (!visited[next.node])
                {
                    queue.Enqueue((next.node, next.cost, node), next.cost);
                }
            }
        }

        int query = int.Parse(sr.ReadLine());
        for (int i = 0; i < query; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = line[0];
            int b = line[1];

            int maxCost = 0; 

            while (a != b) // O(N) LCA지만 QN<= 1000만이니 돌것같다.
            {
                if (depth[a] > depth[b])
                {
                    maxCost = Math.Max(parent[a].cost, maxCost);
                    a = parent[a].node;
                }
                else if (depth[b] > depth[a])
                {
                    maxCost = Math.Max(parent[b].cost, maxCost);
                    b = parent[b].node;
                }
                else
                {
                    maxCost = Math.Max(parent[a].cost, maxCost);
                    maxCost = Math.Max(parent[b].cost, maxCost);
                    a = parent[a].node;
                    b = parent[b].node;
                }
            }

            /* a 와 b가 연결될 필요가 없으니 
             |--a--| |--b--| 같은느낌으로 연결해주면 되고
             트리구조에서 a와 b를 이어주는 간선중에서 가장 큰 간선을 빼면 최적일것이다.
             */
            sw.WriteLine(totalCost - maxCost);
        }
    }
}