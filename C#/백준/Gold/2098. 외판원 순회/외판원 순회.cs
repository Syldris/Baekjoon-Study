#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[,] dist = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < n; j++)
            {
                dist[i, j] = line[j];
            }
        }

        int[,] dp = new int[n, 1 << n]; // 이 상태에서 모든 도시를 방문하고 돌아오는데 필요한 비용
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 1 << n; j++)
            {
                dp[i, j] = -1;
            }
        }

        int result = TSP(0, 1);

        sw.Write(result);

        int TSP(int current, int visited)
        {
            if (dp[current, visited] != -1) // 이미 계산되면 바로 반환
                return dp[current, visited];

            if (visited == (1 << n) - 1) // 전부 방문하면 0번으로 돌아오는 비용만 필요
            {
                if(dist[current, 0] == 0) return dp[current,visited] = int.MaxValue / 2; // 길이 없으면 못감

                else return dp[current,visited] = dist[current, 0]; // dp 테이블을 채우면서 반환
            }

            int result = int.MaxValue / 2;

            for (int next = 0; next < n; next++)
            {
                if (dist[current, next] != 0 && (visited & (1 << next)) == 0) // 길이 있고 방문 안했다면 재귀로 길을 찾음
                {
                    result = Math.Min(dist[current, next] + TSP(next, visited | (1 << next)), result); // 거리 + TSP(다음 지점, 방문 장소)
                }
            }

            return dp[current, visited] = result;
        }

    }
}