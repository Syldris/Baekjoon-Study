#nullable disable
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int rushHourStart = int.Parse(input[2]) * 2; // 시간도 미리 2배 해놓자.
        int rushHourEnd = int.Parse(input[3]) * 2;

        List<(int node, int len, bool rough)>[] graph = new List<(int, int, bool)>[n + 1];
        long[] visited = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
            visited[i] = long.MaxValue;
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int len = line[2] * 2; // 길이를 미리 2배 해놓자.
            bool aTobRouph = line[3] == 1;
            bool bToaRouph = line[4] == 1;

            graph[a].Add((b, len, aTobRouph));
            graph[b].Add((a, len, bToaRouph));
        }


        PriorityQueue<(int node, long time), long> queue = new();
        queue.Enqueue((1, 0), 0);
        visited[1] = 0;

        while (queue.Count > 0)
        {
            (int node, long time) = queue.Dequeue();

            if (time > visited[node]) continue;

            foreach (var next in graph[node])
            {
                long nextTime = time;
                long dist = next.len; // 도로 길이
                if (next.rough)
                {
                    if (nextTime < rushHourStart) // A => 정체 구간 이동
                    {
                        long aToRush = Math.Min(dist, rushHourStart - nextTime); // A|---|정체 시작
                        nextTime += aToRush;
                        dist -= aToRush;
                    }

                    if (dist > 0 && nextTime < rushHourEnd) // 혼잡 구간
                    {
                        long RushStartToEnd = Math.Min((rushHourEnd - nextTime) / 2, dist);
                        nextTime += RushStartToEnd * 2;
                        dist -= RushStartToEnd;
                    }

                    nextTime += dist; // 정체구간 끝|---|B 이동
                }
                else
                {
                    nextTime += dist;
                }

                if (nextTime < visited[next.node])
                {
                    queue.Enqueue((next.node, nextTime), nextTime);
                    visited[next.node] = nextTime;
                }
            }
        }

        double result = 0;
        for (int i = 1; i <= n; i++)
        {
            if (visited[i] != long.MaxValue)
                result = Math.Max(visited[i] / 2.0d, result); // 2배 늘렸으니 다시 절반으로 감소시키기.
        }
        sw.Write(result);
    }
}