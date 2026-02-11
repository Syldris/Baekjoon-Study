#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<(int node, int time)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            graph[line[0]].Add((line[1], line[2])); // a => b
            graph[line[1]].Add((line[0], line[2])); // b => a
        }

        int[] visited = new int[n + 1];
        int[] prev = new int[n + 1];
        Array.Fill(visited, int.MaxValue);

        PriorityQueue<(int node, int time), int> queue = new();
        visited[1] = 0;
        queue.Enqueue((1, 0), 0);

        while (queue.Count > 0)
        {
            (int node, int time) = queue.Dequeue();

            if (node == n)
                break;

            foreach (var next in graph[node])
            {
                int nextTime = time + next.time;

                if (nextTime < visited[next.node])
                {
                    visited[next.node] = nextTime;
                    prev[next.node] = node;
                    queue.Enqueue((next.node, nextTime), nextTime);
                }
            }
        }

        List<(int from, int to)> ignoreEdge = new List<(int, int)>();

        for (int i = n; i != 1; i = prev[i])
        {
            ignoreEdge.Add((prev[i], i));
        }

        int result = 0;

        for (int i = 0; i < ignoreEdge.Count; i++)
        {
            int value = Dijkstar(ignoreEdge[i].from, ignoreEdge[i].to);
            result = Math.Max(result, value);
        }

        sw.Write(result);

        int Dijkstar(int from, int to)
        {
            Array.Fill(visited, int.MaxValue);
            visited[1] = 0;

            PriorityQueue<(int node, int ignoreFrom, int ignoreTo, int time), int> ignoreQueue = new();
            ignoreQueue.Enqueue((1, from, to, 0), 0);

            while (ignoreQueue.Count > 0)
            {
                (int node, int ignoreFrom, int ignoreTo, int time) = ignoreQueue.Dequeue();

                if (node == n)
                    return time;

                foreach (var next in graph[node])
                {
                    if (node == ignoreFrom && next.node == ignoreTo) continue;

                    int nextTime = time + next.time;

                    if (nextTime < visited[next.node])
                    {
                        visited[next.node] = nextTime;
                        ignoreQueue.Enqueue((next.node, ignoreFrom, ignoreTo, nextTime), nextTime);
                    }
                }
            }
            return 0;
        }
    }
}