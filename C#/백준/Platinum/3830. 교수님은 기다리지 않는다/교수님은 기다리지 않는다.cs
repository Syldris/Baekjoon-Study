#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);
        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            if (n == 0 && m == 0)
            {
                return;
            }

            int[] parent = new int[n + 1];
            long?[] dist = new long?[n + 1];

            List<(int node, long value)>[] graph = new List<(int, long)>[n + 1];
            List<(int a, int b, int index)> query = new List<(int, int, int)>();
            long?[] reuslt = new long?[m];

            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
                graph[i] = new List<(int node, long value)>();
            }

            for (int i = 0; i < m; i++)
            {
                string[] line = sr.ReadLine().Split();
                if (line[0] == "!")
                {
                    int a = int.Parse(line[1]);
                    int b = int.Parse(line[2]);
                    int value = int.Parse(line[3]);

                    Union(a, b, value);
                    graph[a].Add((b, value));
                    graph[b].Add((a, -value));
                }
                else
                {
                    int a = int.Parse(line[1]);
                    int b = int.Parse(line[2]);

                    if (Find(parent[a]) == Find(parent[b]))
                    {
                        query.Add((a, b, i));
                    }
                    else
                    {
                        reuslt[i] = long.MaxValue;
                    }
                }
            }

            foreach ((int a, int b, int index) in query)
            {
                if (!dist[a].HasValue || !dist[b].HasValue)
                {
                    DFS(a);
                }
                reuslt[index] = dist[b] - dist[a];
            }

            for (int i = 0; i < m; i++)
            {
                if (reuslt[i].HasValue)
                {
                    sw.WriteLine(reuslt[i] == long.MaxValue ? "UNKNOWN" : reuslt[i]);
                }
            }

            void DFS(int start)
            {
                Queue<int> queue = new();
                dist[start] = 0;
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    foreach (var next in graph[node])
                    {
                        if (!dist[next.node].HasValue)
                        {
                            dist[next.node] = dist[node] + next.value;
                            queue.Enqueue(next.node);
                        }
                    }
                }
            }

            int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            void Union(int a, int b, int value)
            {
                int rootA = Find(a);
                int rootB = Find(b);

                if (rootA != rootB)
                {
                    parent[rootA] = rootB;
                }
            }
        }
    }
}