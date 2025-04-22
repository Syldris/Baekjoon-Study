using System;
using System.Text;
class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            if (n == 0 && m == 0)
                break;

            string[] pos = Console.ReadLine().Split();
            int start = int.Parse(pos[0]);
            int end = int.Parse(pos[1]);

            List<(int pos, int cost)>[] graph = new List<(int, int)>[n + 1];
            for (int i = 0; i <= n; i++)
                graph[i] = new List<(int, int)>();

            for (int i = 0; i < m; i++)
            {
                string[] line = Console.ReadLine().Split();
                int u = int.Parse(line[0]);
                int v = int.Parse(line[1]);
                int cost = int.Parse(line[2]);
                graph[u].Add((v, cost));
            }

            int[] distance = new int[n+1];
            Array.Fill(distance, int.MaxValue);
            distance[start] = 0;

            List<(int from, int to, int cost)>[] prev = new List<(int, int, int)>[n + 1];
            for(int i = 0; i <= n; i++)
            {
                prev[i] = new List<(int, int, int)>();
            }

            PriorityQueue<(int pos, int cost), int> queue = new();

            bool[,] removed = new bool[n, n];

            bool isRemove = false;
            queue.Enqueue((start, 0), 0);
            Dijkstra();

            isRemove = true;
            queue = new();
            queue.Enqueue((start, 0), 0);
            Dijkstra();


            void Dijkstra()
            {
                Array.Fill(distance, int.MaxValue);
                distance[start] = 0;
                int mincost = int.MaxValue;

                while (queue.Count > 0)
                {
                    (int pos, int cost) = queue.Dequeue();

                    if(cost > distance[pos])
                        continue;

                    if (pos == end)
                    {
                        mincost = cost;
                        if(isRemove)
                        {
                            sb.AppendLine(mincost.ToString());
                            return;
                        }
                        else
                        {
                            Backtrack(end);
                            return;
                        }
                    }

                    foreach (var next in graph[pos])
                    {
                        if (removed[pos, next.pos]) continue;
                        int curcost = next.cost + cost;
                        if (curcost < distance[next.pos])
                        {
                            distance[next.pos] = curcost;
                            queue.Enqueue((next.pos, curcost), curcost);
                            if (!isRemove)
                            {
                                prev[next.pos].Clear();
                                prev[next.pos].Add((pos, next.pos, next.cost));
                            }
                        }
                        else if ( curcost == distance[next.pos] && !isRemove)
                            prev[next.pos].Add((pos, next.pos, next.cost));
                    }
                }
                if(mincost == int.MaxValue && isRemove)
                    sb.AppendLine("-1");
            }

            void Backtrack(int cur)
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(cur);
                while (queue.Count > 0)
                {
                    int num = queue.Dequeue();
                    foreach ((int from, int to, int cost) in prev[num])
                    {
                        if (!removed[from, to])
                        {
                            removed[from, to] = true;
                            queue.Enqueue(from);
                        }
                    }
                }
            }
        }
        Console.Write(sb.ToString());
    }
}