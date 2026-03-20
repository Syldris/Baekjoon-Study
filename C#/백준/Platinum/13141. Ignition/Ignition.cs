#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] dist = new int[n, n];
        List<(int node, int len)>[] graph = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new();

        const int max = int.MaxValue >> 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;
                dist[i, j] = max;
            }
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            line[0]--;  // 1index => 0index
            line[1]--;

            dist[line[0], line[1]] = Math.Min(dist[line[0], line[1]], line[2]);
            dist[line[1], line[0]] = Math.Min(dist[line[1], line[0]], line[2]);

            graph[line[0]].Add((line[1], line[2]));
            graph[line[1]].Add((line[0], line[2]));
        }

        for (int v = 0; v < n; v++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, v] + dist[v, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, v] + dist[v, j];
                    }
                }
            }
        }

        int result = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            int value = 0;
            for (int start = 0; start < n; start++)
            {
                foreach ((int end, int len) in graph[start])
                {
                    int maxDist = Math.Max(dist[i, start], dist[i, end]); // i => start, i => end 즉 한정점에서의 start, end 비교.
                    int diff = Math.Abs(dist[i, start] - dist[i, end]);

                    int curlen = len; // 현재 남은 길이

                    curlen -= diff; // 시간 차이만큼 더 빨리온 정점에서 간선으로 출발해서 길이를 줄임 
                    value = Math.Max(value, maxDist * 2 + curlen); // 간선은 0미만으로는 안줄어들게끔 0제한.
                }
            }
            result = Math.Min(result, value); // 한 정점안에서의 max값을 구하고 정점중에서 제일 최선을 고른다.
        }

        sw.WriteLine($"{((float)result / 2):F1}"); // 정점까지의 거리는 정상적으로 1배처리되고, 남은 간선은 두정점에서 출발해서 줄이므로 0.5배.
    }
}