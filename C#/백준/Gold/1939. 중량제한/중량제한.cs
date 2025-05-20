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

        List<(int node, int weightLimit)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            int weightLimit = int.Parse(line[2]);

            graph[start].Add((end, weightLimit));
            graph[end].Add((start, weightLimit));
        }

        int[] visited = new int[n + 1];
        PriorityQueue<(int node, int cost), int> queue = new();

        string[] input = sr.ReadLine().Split();
        int startPos = int.Parse((input[0]));
        int endPos = int.Parse((input[1]));

        queue.Enqueue((startPos, int.MaxValue), 0);

        while (queue.Count > 0)
        {
            var (node, cost) = queue.Dequeue();

            if(node == endPos)
            {
                sw.Write(cost);
                return;
            }

            foreach (var next in graph[node])
            {
                int curcost = Math.Min(cost, next.weightLimit);
                if (curcost > visited[next.node])
                {
                    visited[next.node] = curcost;
                    queue.Enqueue((next.node, curcost), -curcost);
                }
            }
        }
    }
}