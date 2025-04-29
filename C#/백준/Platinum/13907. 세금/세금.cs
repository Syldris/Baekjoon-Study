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

        List<(long pos, long cost)>[] graph = new List<(long, long)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(long, long)>();
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

        PriorityQueue<(long pos, long cost, long edgeCount), (long cost, long edgeCount)> queue = new();
        queue.Enqueue((start, 0, 0), (0, 0));

        long[,] distance = new long[n + 1, n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                distance[i,j] = long.MaxValue;
            }
        }

        distance[start,0] = 0;

        while (queue.Count > 0)
        {
            (long pos, long cost, long edgeCount) = queue.Dequeue();
            if (pos == end)
            {
                continue;
            }

            foreach (var next in graph[pos])
            {
                long curcost = next.cost + cost;
                long nextEdge = edgeCount + 1;
                if(nextEdge > n) 
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
        long min = long.MaxValue;
        for (int i = 0; i <= n; i++)
        {
            if (distance[end, i] < min)
                min = distance[end, i];
        }
        sb.AppendLine(min.ToString());

        long totalTax = 0;

        for (int i = 0; i < k; i++)
        {
            long tax = long.Parse(sr.ReadLine());
            totalTax += tax;

            long taxedMin = long.MaxValue;
            for (int j = 0; j <= n; j++)
            {
                if (distance[end, j] == long.MaxValue) continue;
                taxedMin = Math.Min(taxedMin, distance[end, j] + j * totalTax);
            }
            sb.AppendLine(taxedMin.ToString());
        }
        sw.Write(sb);
        sw.Close();
        sr.Close();
    }
}