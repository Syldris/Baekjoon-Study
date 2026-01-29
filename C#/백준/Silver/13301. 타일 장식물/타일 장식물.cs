#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        long[] dp = new long[81];
        dp[0] = 1;
        dp[1] = 1;
       
        for (int i = 2; i <= n; i++)
        {
            dp[i] += dp[i - 1] + dp[i - 2];
        }
        sw.Write(dp[n] * 2 + dp[n - 1] * 2);
    }
}