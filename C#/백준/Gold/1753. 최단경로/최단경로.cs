using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int V = int.Parse(input[0]);
        int E = int.Parse(input[1]);
        int K = int.Parse(Console.ReadLine());

        List<(int node, int time)>[] graph = new List<(int, int)>[V + 1];
        for (int i = 1; i <= V; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < E; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int u = int.Parse(inputs[0]);
            int v = int.Parse(inputs[1]);
            int w = int.Parse(inputs[2]);
            graph[u].Add((v, w));
        }

        PriorityQueue<(int node, int time), int> queue = new PriorityQueue<(int, int), int>();

        int[] dist = new int[V + 1];
        Array.Fill(dist, int.MaxValue);
        dist[K] = 0;
        queue.Enqueue((K, 0), 0);
        while (queue.Count > 0)
        {
            (int node, int time) = queue.Dequeue();
            foreach (var item in graph[node])
            {
                int curtime = time + item.time;
                if(curtime <= dist[item.node])
                {
                    dist[item.node] = curtime;
                    queue.Enqueue((item.node, curtime), curtime);
                }
            }
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= V; i++)
        {
            if(dist[i] == int.MaxValue)
                sb.AppendLine("INF");
            else
                sb.AppendLine(dist[i].ToString());
        }
        Console.WriteLine(sb);
    }
}
