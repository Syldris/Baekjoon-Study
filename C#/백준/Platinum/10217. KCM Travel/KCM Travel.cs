#nullable disable
public readonly struct Node
{
    public readonly int pos;
    public readonly int cost;
    public readonly int time;

    public Node(int pos, int cost, int time)
    {
        this.pos = pos;
        this.cost = cost;
        this.time = time;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int k = int.Parse(input[2]);

            List<Node>[] graph = new List<Node>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new();

            for (int i = 0; i < k; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                graph[line[0]].Add(new Node(line[1], line[2], line[3])); // 출발지역 => (도착지점, 비용, 시간)
            }

            int[,] dp = new int[n + 1, m + 1]; // [지역, 현재 비용] => 시간
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            dp[1, 0] = 0;

            for (int cost = 0; cost <= m; cost++)
            {
                for (int node = 1; node <= n; node++)
                {
                    if (dp[node, cost] == int.MaxValue) continue; // 미 도착지점에선 출발금지!

                    int time = dp[node, cost];

                    foreach (var edge in graph[node])
                    {
                        int nextTime = time + edge.time;
                        int nextCost = cost + edge.cost;

                        if (nextCost > m) continue; // 비용초과시 이동불가능!

                        if (nextTime < dp[edge.pos, nextCost])
                        {
                            dp[edge.pos, nextCost] = nextTime;
                        }
                    }
                }
            }

            int minTime = int.MaxValue;
            for (int cost = 0; cost <= m; cost++)
            {
                minTime = Math.Min(minTime, dp[n, cost]);
            }

            sw.WriteLine(minTime == int.MaxValue ? "Poor KCM" : minTime);
        }
    }
}