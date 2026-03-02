#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        List<(int node, int len)>[] graph = new List<(int, int)>[n + 1];
        int[] visited = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
            visited[i] = int.MaxValue;
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1], line[2])); // a => b
            graph[line[1]].Add((line[0], line[2])); // b = > a
        }

        PriorityQueue<(int node, int cost), int> queue = new();
        for (int i = 0; i < k; i++)
        {
            int startNode = int.Parse(sr.ReadLine());
            visited[startNode] = 0;
            queue.Enqueue((startNode, 0), 0); // 멀티소스 다익
        }

        while (queue.Count > 0)
        {
            (int node, int cost) = queue.Dequeue();

            if (cost > visited[node]) continue;

            foreach (var next in graph[node])
            {
                int nextCost = cost + next.len;

                if (nextCost < visited[next.node])
                {
                    visited[next.node] = nextCost;
                    queue.Enqueue((next.node, nextCost), nextCost);
                }
            }
        }

        int maxDist = 0;
        for (int i = 1; i <= n; i++)
        {
            maxDist = Math.Max(visited[i], maxDist);
        }

        for (int i = 1; i <= n; i++) // 모든 간선을 탐색
        {
            foreach ((int node, int len) in graph[i])
            {
                int curDist = ((visited[i] + visited[node] + len + 1) / 2);
                maxDist = Math.Max(curDist, maxDist);
            }
        }

        sw.Write(maxDist);
    }
}