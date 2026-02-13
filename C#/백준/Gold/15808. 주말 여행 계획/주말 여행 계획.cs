#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        List<(int node, int cost)>[] graph = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new();

        int[] visited = new int[n];
        Array.Fill(visited, int.MinValue);

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            for (int j = 0; j < n; j++)
            {
                int cost = line[j];
                if (cost != 0)
                {
                    graph[i].Add((j, cost));
                }
            }
        }

        int maxValue = int.MinValue;

        string[] input = sr.ReadLine().Split();
        int p = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        PriorityQueue<(int node, int cost), int> queue = new();

        int[] hotel = new int[n];

        for (int i = 0; i < p; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int pos = line[0] - 1;
            int value = line[1];
            queue.Enqueue((pos, value), -value);
            visited[pos] = value;
        }

        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int pos = line[0] - 1;
            int value = line[1];

            hotel[pos] = value;
        }

        while (queue.Count > 0)
        {
            (int node, int cost) = queue.Dequeue();

            if (cost < visited[node]) continue;

            if (hotel[node] != 0)
            {
                maxValue = Math.Max(cost + hotel[node], maxValue);
            }

            foreach (var next in graph[node])
            {
                int nextCost = cost - next.cost;

                if (nextCost > visited[next.node])
                {
                    visited[next.node] = nextCost;
                    queue.Enqueue((next.node, nextCost), -nextCost);
                }
            }
        }

        sw.Write(maxValue);
    }
}