#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int k = int.Parse(input[2]);

            List<(int node, int cost, int time)>[] graph = new List<(int, int, int)>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new();

            for (int i = 0; i < k; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                graph[line[0]].Add((line[1], line[2], line[3])); // 출발지역 => (도착지점, 비용, 시간)
            }

            for (int i = 1; i <= n; i++)
            {
                graph[i].Sort((a, b) => a.time.CompareTo(b.time)); // 효율적 탐색을 위해 시간순으로 정렬
            }

            int[,] visited = new int[n + 1, m + 1]; // [지역, 현재 비용] => 시간
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    visited[i, j] = int.MaxValue;
                }
            }

            PriorityQueue<(int node, int cost, int time), int> queue = new();
            queue.Enqueue((1, 0, 0), 0);
            visited[1, 0] = 0;

            bool find = false;

            while (queue.Count > 0)
            {
                (int node, int cost, int time) = queue.Dequeue();

                if (time > visited[node, cost]) continue;

                if (node == n)
                {
                    sw.Write(time);
                    find = true;
                    break;
                }

                foreach (var next in graph[node])
                {
                    int nextCost = cost + next.cost;
                    int nextTime = time + next.time;

                    if (nextCost > m) // 총 비용이 돈을 넘으면 못감
                        continue;

                    if (nextTime < visited[next.node, nextCost])
                    {
                        visited[next.node, nextCost] = nextTime;

                        queue.Enqueue((next.node, nextCost, nextTime), nextTime);
                    }
                }
            }

            if (!find)
                sw.Write("Poor KCM");
        }

    }
}