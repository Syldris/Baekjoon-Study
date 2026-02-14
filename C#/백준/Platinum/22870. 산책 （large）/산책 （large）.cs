#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<(int node, int time)>[] graph = new List<(int, int)>[n + 1];
        int[] prev = new int[n + 1];
        int[] visited = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
            visited[i] = int.MaxValue;
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1], line[2]));
            graph[line[1]].Add((line[0], line[2]));
        }


        string[] input2 = sr.ReadLine().Split();
        int a = int.Parse(input2[0]);
        int b = int.Parse(input2[1]);

        PriorityQueue<(int node, int time), int> queue = new();
        queue.Enqueue((b, 0), 0);
        visited[b] = 0;

        while (queue.Count > 0)
        {
            (int node, int time) = queue.Dequeue();

            if (time > visited[node]) continue;

            if (node == a) break;

            foreach (var next in graph[node])
            {
                int nextTime = time + next.time;
                if (nextTime < visited[next.node])
                {
                    prev[next.node] = node;

                    queue.Enqueue((next.node, nextTime), nextTime);
                    visited[next.node] = nextTime;
                }
                else if (nextTime == visited[next.node] && node < prev[next.node])
                {
                    prev[next.node] = node;
                }
            }
        }

        bool[] ignore = new bool[n + 1];
        TrackBack(a);

        void TrackBack(int node)
        {
            if (node == b)
                return;

            ignore[node] = true;
            TrackBack(prev[node]);
        }
        ignore[a] = false;

        int dist = visited[a]; // a => b 의 최단 길이는 b => a와 같다
        Array.Fill(visited, int.MaxValue);
        visited[b] = dist;

        queue.Clear();

        queue.Enqueue((b, dist), dist);
        while (queue.Count > 0)
        {
            (int node, int time) = queue.Dequeue();

            if (time > visited[node]) continue;

            if (node == a)
            {
                sw.Write(time);
                return;
            }

            foreach (var next in graph[node])
            {
                if (ignore[next.node]) continue;

                int nextTime = time + next.time;

                if (nextTime < visited[next.node])
                {
                    visited[next.node] = nextTime;
                    queue.Enqueue((next.node, nextTime), nextTime);
                }
            }
        }
    }
}