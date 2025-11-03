#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input1 = sr.ReadLine().Split();
        string[] input2 = sr.ReadLine().Split();
        int n = int.Parse(input1[0]);
        int m = int.Parse(input1[1]);

        int start = int.Parse(input2[0]);
        int end = int.Parse(input2[1]);

        List<(int node, int weight)>[] graph = new List<(int node, int weight)>[n+1];
        int[] visited = new int[n+1];


        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
        }
        visited[start] = int.MaxValue;

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int weight = int.Parse(line[2]);

            graph[a].Add((b, weight));
            graph[b].Add((a, weight));
        }

        PriorityQueue<(int node, int wegiht), int> queue = new();
        queue.Enqueue((start, int.MaxValue), 0);

        while (queue.Count > 0)
        {
            (int node, int weight) = queue.Dequeue();
            if (node == end)
            {
                sw.Write(weight);
                return;
            }

            foreach (var item in graph[node])
            {
                int curweight = Math.Min(weight, item.weight);
                if (curweight > visited[item.node])
                {
                    visited[item.node] = curweight;
                    queue.Enqueue((item.node, curweight), -curweight);
                }
            }
        }
        sw.Write(0);
    }
}