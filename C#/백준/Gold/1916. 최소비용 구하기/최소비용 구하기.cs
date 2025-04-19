using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        List<(int node, int time)>[] graph = new List<(int, int)>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int u = int.Parse(inputs[0]);
            int v = int.Parse(inputs[1]);
            int w = int.Parse(inputs[2]);
            graph[u].Add((v, w));
        }

        string[] input = Console.ReadLine().Split();

        int start = int.Parse(input[0]);
        int end = int.Parse(input[1]);

        PriorityQueue<(int node, int time), int> queue = new PriorityQueue<(int, int), int>();
        queue.Enqueue((start, 0), 0);

        int[] dist = new int[n + 1];
        dist[start] = 0;
        Array.Fill(dist, int.MaxValue);

        while (queue.Count > 0)
        {
            (int node, int time) = queue.Dequeue();

            if(node == end)
            {
                Console.WriteLine(time);
                return;
            }    

            foreach (var item in graph[node])
            {
                int curtime = time + item.time;
                if (curtime < dist[item.node])
                {
                    dist[item.node] = curtime;
                    queue.Enqueue((item.node, curtime), curtime);
                }
            }
        }
    }
}
