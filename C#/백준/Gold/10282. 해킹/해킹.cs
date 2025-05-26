#nullable disable
using System.Collections;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcase; t++)
        {
            string[] inputs = sr.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int d = int.Parse(inputs[1]);
            int c = int.Parse(inputs[2]);
            List<(int node, int time)>[] graph = new List<(int, int)>[n + 1];
            int[] visited = new int[n + 1];
            visited[c] = 0;
            bool[] hacking = new bool[n + 1];
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new List<(int, int)>();
                visited[i] = int.MaxValue;
            }

            for (int i = 0; i < d; i++)
            {
                string[] input = sr.ReadLine().Split();
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);
                int time = int.Parse(input[2]);
                graph[b].Add((a, time));
            }

            int maxtime = 0;

            PriorityQueue<(int node, int time), int> queue = new();
            queue.Enqueue((c, 0), 0);
            while (queue.Count > 0)
            {
                (int node, int time) = queue.Dequeue();
                if(!hacking[node])
                    maxtime = Math.Max(maxtime, time);
                hacking[node] = true;
                foreach (var next in graph[node])
                {
                    int curtime = time + next.time;
                    if(curtime < visited[next.node])
                    {
                        visited[next.node] = curtime;
                        queue.Enqueue((next.node, curtime), curtime);
                    }
                }
            }
            int computer = 0;
            for (int i = 1; i <= n; i++)
            {
                if (hacking[i])
                    computer++;
            }
            sw.WriteLine($"{computer} {maxtime}");
        }
    }
}