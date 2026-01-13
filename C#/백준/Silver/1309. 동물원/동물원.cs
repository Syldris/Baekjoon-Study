#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[,] dp = new int[100001, 3];
        const int mod = 9901;

        dp[1, 0] = 1;
        dp[1, 1] = 1;
        dp[1, 2] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i, 0] = (dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2]) % mod;
            dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 1]) % mod;
            dp[i, 2] = (dp[i - 1, 0] + dp[i - 1, 2]) % mod;
        }

        sw.Write((dp[n, 0] + dp[n, 1] + dp[n, 2]) % mod);
    }
}