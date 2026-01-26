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

        List<(int node, int len)>[] graph = new List<(int node, int len)>[n + 1];
        long[,] visited = new long[2501, 2501];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
            for (int j = 1; j <= 2500; j++)
                visited[i, j] = long.MaxValue;
        }

        int[] cost = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int len = line[2];

            graph[a].Add((b, len));
            graph[b].Add((a, len));
        }


        PriorityQueue<(int node, long value, int minCost), long> queue = new();
        queue.Enqueue((1, 0, cost[0]), 0);
        visited[1, cost[0]] = 0;

        while (queue.Count > 0)
        {
            (int node, long value, int minCost) = queue.Dequeue();

            if (node == n)
            {
                sw.Write(value);
                return;
            }

            foreach (var next in graph[node])
            {
                long movecost = next.len * minCost + value;

                if (movecost < visited[next.node, minCost])
                {
                    visited[next.node, minCost] = movecost;

                    int nextMinCost = Math.Min(cost[next.node - 1], minCost);
                    queue.Enqueue((next.node, movecost, nextMinCost), movecost);
                }
            }
        }
    }
}