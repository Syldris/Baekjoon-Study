#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        long[] distance = new long[n+1];
        Array.Fill(distance, long.MaxValue);
        distance[1] = 0;
        List<(int from, int to, int cost)> graph = new List<(int from, int to, int cost)>();

        for (int i = 0; i < m; i++)
        {
            string[] input = sr.ReadLine().Split();
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            int cost = int.Parse(input[2]);

            graph.Add((start, end, cost));
        }

        for (int i = 1; i <= n; i++)
        {
            foreach (var (from, to, cost) in graph)
            {
                if (distance[from] != long.MaxValue && distance[from] + cost < distance[to])
                {
                    distance[to] = distance[from] + cost;
                }
            }
        }

        for (int i = 1; i <= n; i++)
        {
            foreach (var (from, to, cost) in graph)
            {
                if (distance[from] != long.MaxValue && distance[from] + cost < distance[to])
                {
                    sw.Write(-1);
                    return;
                }
            }
        }

        for (int i = 2; i <= n; i++)
        {
            sw.WriteLine(distance[i] != long.MaxValue ? distance[i] : -1);
        }
    }
}