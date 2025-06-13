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
        List<(int node, long cost)>[] graph = new List<(int node, long cost)>[n + 1];
        long[] distance = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int node, long cost)>();
            distance[i] = long.MaxValue;
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int start = line[0];
            int end = line[1];
            int cost = line[2];
            graph[end].Add((start, cost));
        }

        PriorityQueue<(int node, long cost), long> queue = new();
        int[] endPos = sr.ReadLine().Split().Select(int.Parse).ToArray();

        foreach (var item in endPos)
        {
            distance[item] = 0;
            queue.Enqueue((item, 0), 0);
        }
        

        while (queue.Count > 0)
        {
            (int node, long cost) = queue.Dequeue();

            if (cost > distance[node])
                continue;

            foreach (var next in graph[node])
            {
                long curcost = next.cost + cost;
                if (curcost < distance[next.node])
                {
                    distance[next.node] = curcost;
                    queue.Enqueue((next.node, curcost), curcost);
                }
            }
        }

        long maxcost = 0;
        int index = 0;
        for (int i = n; i > 0; i--)
        {
            if (distance[i] >= maxcost)
            {
                maxcost = distance[i];
                index = i;
            }
        }
        sw.WriteLine(index);
        sw.WriteLine(maxcost);
    }
}