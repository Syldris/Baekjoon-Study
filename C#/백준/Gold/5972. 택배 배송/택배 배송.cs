using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            int cost = int.Parse(line[2]);

            graph[start].Add((end, cost));
            graph[end].Add((start, cost));
        }

        int[] visited = new int[n + 1];
        Array.Fill(visited, int.MaxValue);
        visited[1] = 0;

        PriorityQueue<(int node, int cost), int> queue = new();
        queue.Enqueue((1, 0), 0);
        while (queue.Count > 0)
        {
            var (node, cost) = queue.Dequeue();
            if(node == n)
            {
                sw.Write(cost);
                return;
            }
            foreach(var next in graph[node])
            {
                int curcost = cost + next.cost;
                if (curcost < visited[next.node])
                {
                    visited[next.node] = curcost;
                    queue.Enqueue((next.node, curcost), curcost);
                }
            }
        }
    }
}