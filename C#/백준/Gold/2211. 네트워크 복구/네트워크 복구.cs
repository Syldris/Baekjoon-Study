#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        List<(int node, int cost)>[] graph = new List<(int node, int cost)>[n+1];
        int[] distance = new int[n + 1];
        int[] parents = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int node, int cost)>();
            distance[i] = int.MaxValue;
        }
        distance[1] = 0;

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int start = line[0];
            int end = line[1];
            int cost = line[2];
            graph[start].Add((end, cost));
            graph[end].Add((start, cost));
        }

        PriorityQueue<(int node, int cost), int> queue = new();
        queue.Enqueue((1, 0), 0);

        while (queue.Count > 0)
        {
            (int node, int cost) = queue.Dequeue();

            if(cost > distance[node])
                continue;

            foreach (var next in graph[node])
            {
                int curcost = cost + next.cost;
                if (curcost < distance[next.node])
                {
                    distance[next.node] = curcost;
                    queue.Enqueue((next.node, curcost), curcost);
                    parents[next.node] = node;
                }
            }
        }

        sw.WriteLine(n - 1);
        for (int i = 2; i <= n; i++)
        {
            sw.WriteLine($"{parents[i]} {i}");
        }
    }
}