using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int k = int.Parse(inputs[2]);

        string[] input = sr.ReadLine().Split();
        int start = int.Parse(input[0]);
        int end = int.Parse(input[1]);

        List<(int pos, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int s = int.Parse(line[0]);
            int d = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            graph[s].Add((d, cost));
            graph[d].Add((s, cost));
        }

        PriorityQueue<(int pos, int cost, int edgeCount), (int cost, int edgeCount)> queue = new();
        queue.Enqueue((start, 0, 0), (0, 0));

        int[,] distance = new int[n + 1, n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                distance[i, j] = int.MaxValue;
            }
        }

        distance[start, 0] = 0;

        while (queue.Count > 0)
        {
            (int pos, int cost, int edgeCount) = queue.Dequeue();
            if (pos == end)
            {
                continue;
            }

            foreach (var next in graph[pos])
            {
                int curcost = next.cost + cost;
                int nextEdge = edgeCount + 1;
                if (nextEdge > n)
                    continue;

                if (distance[next.pos, nextEdge] > curcost)
                {
                    distance[next.pos, nextEdge] = curcost;
                    queue.Enqueue((next.pos, curcost, nextEdge), (curcost, nextEdge));
                }
            }
        }

        StringBuilder sb = new StringBuilder();
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int min = int.MaxValue;
        for (int i = 0; i <= n; i++)
        {
            if (distance[end, i] < min)
                min = distance[end, i];
        }
        sb.AppendLine(min.ToString());

        int totalTax = 0;

        for (int i = 0; i < k; i++)
        {
            int tax = int.Parse(sr.ReadLine());
            totalTax += tax;

            int taxedMin = int.MaxValue;
            for (int j = 0; j <= n; j++)
            {
                if (distance[end, j] == int.MaxValue) continue;
                taxedMin = Math.Min(taxedMin, distance[end, j] + j * totalTax);
            }
            sb.AppendLine(taxedMin.ToString());
        }
        sw.Write(sb);
        sw.Close();
        sr.Close();
    }
}