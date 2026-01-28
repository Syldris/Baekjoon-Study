#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        const int mod = 1000000007;

        int[,] dp = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            dp[i, 1] = 1;
        }
        for (int i = 1; i <= m; i++)
        {
            dp[1, i] = 1;
        }

        for (int y = 2; y <= n; y++)
        {
            for (int x = 2; x <= m; x++)
            {
                dp[y, x] = ((dp[y, x - 1] + dp[y - 1, x]) % mod + dp[y - 1, x - 1]) % mod;
            }
        }
        sw.Write(dp[n, m]);
    }
}