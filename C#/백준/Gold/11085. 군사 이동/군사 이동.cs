#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        string[] input2 = sr.ReadLine().Split();
        int start = int.Parse(input2[0]);
        int end = int.Parse(input2[1]);

        int[] visited = new int[n];
        List<(int to, int cost)>[] graph = new List<(int pos, int value)>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int to, int cost)>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int cost = int.Parse(line[2]);

            graph[a].Add((b,cost));
            graph[b].Add((a, cost));
        }

        PriorityQueue<(int pos, int cost), int> queue = new PriorityQueue<(int pos, int cost), int>();

        int result = 0;
        queue.Enqueue((start, int.MaxValue), 0);

        while (queue.Count > 0)
        {
            (int pos, int cost) = queue.Dequeue();

            if (pos == end)
            {
                result = Math.Max(result, cost);
                continue;
            }

            foreach (var item in graph[pos])
            {
                int width = Math.Min(cost, item.cost);
                if (width > visited[item.to])
                {
                    queue.Enqueue((item.to, width), -width);
                    visited[item.to] = width;
                }
            }
        }

        sw.WriteLine(result);
    }
}