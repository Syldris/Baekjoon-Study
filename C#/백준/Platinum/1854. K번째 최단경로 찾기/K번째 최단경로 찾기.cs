using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        List<(int pos, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int from = int.Parse(line[0]);
            int to = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            graph[from].Add((to, cost));
        }

        PriorityQueue<int,int>[] dist = new PriorityQueue<int, int>[n+1];
        for (int i = 1; i <= n; i++)
        {
            dist[i] = new PriorityQueue<int, int>();
        }
        dist[1].Enqueue(0, 0);

        PriorityQueue<(int pos, int cost),int> queue = new();
        queue.Enqueue((1, 0), 0);

        while (queue.Count > 0)
        {
            (int pos, int cost) = queue.Dequeue();


            foreach (var next in graph[pos])
            {
                int curcost = cost + next.cost;
                if (dist[next.pos].Count < k)
                {
                    dist[next.pos].Enqueue(curcost, -curcost);

                    queue.Enqueue((next.pos,curcost),curcost);
                }
                else if (dist[next.pos].Peek() > curcost)
                {
                    dist[next.pos].Dequeue();
                    dist[next.pos].Enqueue(curcost, -curcost);

                    queue.Enqueue((next.pos, curcost), curcost);
                }
            }
        }



        for (int i = 1; i <= n; i++)
        {
            if (dist[i].Count < k)
                sw.WriteLine(-1);
            else
                sw.WriteLine(dist[i].Dequeue());
        }
        sr.Close();
        sw.Close();
    }
}