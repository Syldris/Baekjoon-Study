using System;
using System.Text;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int k = int.Parse(inputs[2]);

        List<(int end, int time)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 1; i <= m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int startPos = int.Parse(line[0]);
            int endPos = int.Parse(line[1]);
            int time = int.Parse(line[2]);

            graph[startPos].Add((endPos, time));
        }

        int[] nodetime = new int[n + 1];

        for(int i = 1; i <= n; i++)
        {
            nodetime[i] += Dijkstra(i);
            nodetime[i] += ReverseDijkstra(i);
        }

        Console.WriteLine(nodetime.Max());

        int Dijkstra(int startPos)
        {
            int[] dist = new int[n + 1];
            for(int i = 1; i<=n; i++) dist[i] = int.MaxValue;
            dist[startPos] = 0;

            PriorityQueue<(int curpos, int time), int> queue = new PriorityQueue<(int, int), int>();
            queue.Enqueue((startPos, 0), 0);
            while (queue.Count > 0)
            {
                (int curPos, int time) = queue.Dequeue();

                if(curPos == k)
                {
                    return time;
                }

                if (time > dist[curPos])
                    continue;

                foreach (var node in graph[curPos])
                {
                    int newTime = time + node.time;

                    if (newTime < dist[node.end])
                    {
                        dist[node.end] = newTime;
                        queue.Enqueue((node.end, newTime), newTime);
                    }
                }
            }
            return 0;
        }

        int ReverseDijkstra(int endPos)
        {
            int[] dist = new int[n + 1];
            for (int i = 1; i <= n; i++) dist[i] = int.MaxValue;
            dist[k] = 0;

            PriorityQueue<(int curpos, int time), int> queue = new PriorityQueue<(int, int), int>();
            queue.Enqueue((k, 0), 0);
            while (queue.Count > 0)
            {
                (int curPos, int time) = queue.Dequeue();

                if (curPos == endPos)
                {
                    return time;
                }

                if (time > dist[curPos])
                    continue;

                foreach (var node in graph[curPos])
                {
                    int newTime = time + node.time;

                    if (newTime < dist[node.end])
                    {
                        dist[node.end] = newTime;
                        queue.Enqueue((node.end, newTime), newTime);
                    }
                }
            }
            return 0;
        }
    }
}
