using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        
        List<(int node,int cost)>[] graph = new List<(int, int)>[n+1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            graph[start].Add((end, cost));
            graph[end].Add((start, cost));
        }

        string[] inputs = Console.ReadLine().Split();
        int s = int.Parse(inputs[0]);
        int t = int.Parse(inputs[1]);

        PriorityQueue<(int pos, int totalcost), int> queue = new();
        queue.Enqueue((s, 0), 0);

        int[] dist = new int[n+1];
        Array.Fill(dist, int.MaxValue);
        dist[s] = 0;
        while (queue.Count > 0)
        {
            (int pos, int totalcost) = queue.Dequeue();
            if (pos == t)
            {
                Console.WriteLine(totalcost);
                return;
            }

            foreach (var next in graph[pos])
            {
                int curcost = next.cost + totalcost;
                if (curcost < dist[next.node])
                {
                    dist[next.node] = curcost;
                    queue.Enqueue((next.node, curcost), curcost);
                }
            }
        }
    }
}