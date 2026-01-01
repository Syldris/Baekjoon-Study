#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        List<(int node, int cost)>[] graph = new List<(int node, int cost)>[n + 1];
        List<int>[] prev = new List<int>[n + 1];

        int[] dist = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int node, int cost)>();
            prev[i] = new List<int>();
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];
            graph[a].Add((b, cost));
        }

        string[] input = sr.ReadLine().Split();
        int start = int.Parse(input[0]);
        int end = int.Parse(input[1]);
        int value = 0;

        Queue<(int node, int cost)> queue = new();
        queue.Enqueue((start, 0));
        while (queue.Count > 0)
        {
            (int node, int cost) = queue.Dequeue();

            if (cost < dist[node])
                continue;

            if (node == end)
            {
                if (cost > value)
                {
                    value = cost;
                }
                continue;
            }

            foreach (var next in graph[node])
            {
                int nextcost = cost + next.cost;
                if (nextcost > dist[next.node])
                {
                    prev[next.node].Clear();
                    prev[next.node].Add(node);

                    dist[next.node] = nextcost;
                    queue.Enqueue((next.node, nextcost));
                }
                else if (nextcost == dist[next.node])
                {
                    prev[next.node].Add(node);
                }
            }
        }

        int count = 0;
        bool[] visited = new bool[n + 1];

        Queue<int> trackBack = new();
        trackBack.Enqueue(end);

        while (trackBack.Count > 0)
        {
            int node = trackBack.Dequeue();
            foreach (var next in prev[node])
            {
                count++;
                if (!visited[next])
                {
                    trackBack.Enqueue(next);
                    visited[next] = true;
                }
            }
        }

        sw.WriteLine(value);
        sw.WriteLine(count);
    }
}