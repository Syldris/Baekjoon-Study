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

        (int pos, int value)[] travel = new (int, int)[p];
        (int pos, int value)[] hotel = new (int, int)[q];

        for (int i = 0; i < p; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            travel[i] = (line[0] - 1, line[1]);
        }

        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            hotel[i] = (line[0] - 1, line[1]);
        }

        if (p <= q) // 여행지 => 숙소
        {
            for (int i = 0; i < p; i++)
            {
                Array.Fill(visited, int.MaxValue);
                Dijkstra(travel[i].pos);

                for (int j = 0; j < q; j++)
                {
                    int value = travel[i].value + hotel[j].value - visited[hotel[j].pos];
                    maxValue = Math.Max(maxValue, value);
                }
            }
        }
        else // 숙소 => 여행지
        {
            for (int i = 0; i < q; i++)
            {
                Array.Fill(visited, int.MaxValue);
                Dijkstra(hotel[i].pos);

                for (int j = 0; j < p; j++)
                {
                    int value = hotel[i].value + travel[j].value - visited[travel[j].pos];
                    maxValue = Math.Max(maxValue, value);
                }
            }
        }

        sw.Write(maxValue);


        void Dijkstra(int start)
        {
            PriorityQueue<(int node, int cost), int> queue = new();
            queue.Enqueue((start, 0), 0);
            visited[start] = 0;

            while (queue.Count > 0)
            {
                (int node, int cost) = queue.Dequeue();

                if (cost > visited[node]) continue;

                foreach (var next in graph[node])
                {
                    int nextCost = next.cost + cost;

                    if (nextCost < visited[next.node])
                    {
                        visited[next.node] = nextCost;
                        queue.Enqueue((next.node, nextCost), nextCost);
                    }
                }
            }
        }
    }
}