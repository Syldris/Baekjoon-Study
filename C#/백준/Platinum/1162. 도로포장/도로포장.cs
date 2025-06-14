#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        List<(int node, int k, long cost)>[] graph = new List<(int node, int k, long cost)>[n + 1];
        long[,] distance = new long[n + 1, k + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int node, int k, long cost)>();
            for (int j = 0; j <= k; j++)
            {
                distance[i,j] = long.MaxValue;
            }
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int start = line[0];
            int end = line[1];
            int cost = line[2];
            graph[start].Add((end, 0, cost));
            graph[end].Add((start, 0, cost));
        }

        long minValue = long.MaxValue;

        PriorityQueue<(int node, int kCount, long cost), long> queue = new();
        queue.Enqueue((1, 0, 0), 0);
        while (queue.Count > 0)
        {
            (int node, int kCount, long cost) = queue.Dequeue();

            if (node == n)
            {
                minValue = Math.Min(minValue, cost);
                continue;
            }

            if (cost > distance[node, kCount])
            {
                continue;
            }

            foreach (var next in graph[node])
            {
                long curcost = cost + next.cost;

                if (curcost < distance[next.node, kCount])
                {
                    distance[next.node, kCount] = curcost;
                    queue.Enqueue((next.node, kCount, curcost), curcost);
                }
                if (kCount < k)
                {
                    int curKCount = kCount + 1;
                    if (cost < distance[next.node, curKCount])
                    {
                        distance[next.node,curKCount] = cost;
                        queue.Enqueue((next.node, curKCount, cost), cost);
                    }
                }
            }
        }
        sw.Write(minValue);
    }
}