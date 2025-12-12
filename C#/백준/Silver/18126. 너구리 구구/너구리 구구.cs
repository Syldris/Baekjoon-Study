#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        List<(int node, long cost)>[] graph = new List<(int, long)>[n + 1];
        long[] distacne = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, long)>();
            distacne[i] = long.MaxValue;
        }
        distacne[1] = 0;

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int cost = int.Parse(line[2]);

            graph[a].Add((b, cost));
            graph[b].Add((a, cost));
        }

        Queue<(int node, long cost)> queue = new();
        queue.Enqueue((1, 0));

        while (queue.Count > 0)
        {
            (int node, long cost) = queue.Dequeue();
            foreach (var next in graph[node])
            {
                long curcost = cost + next.cost;
                if (curcost < distacne[next.node])
                {
                    distacne[next.node] = curcost;
                    queue.Enqueue((next.node, curcost));
                }
            }
        }

        sw.Write(distacne.Max());
    }
}