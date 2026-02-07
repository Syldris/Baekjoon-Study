#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] dp = new int[100001];
        Array.Fill(dp, int.MaxValue);
        dp[2] = 1;
        dp[4] = 2;
        dp[5] = 1;
        for (int i = 6; i <= n; i++)
        {
            if (dp[i - 2] != int.MaxValue)
            {
                dp[i] = dp[i - 2] + 1;
            }
            if (dp[i - 5] != int.MaxValue)
            {
                dp[i] = Math.Min(dp[i - 5] + 1, dp[i]);
            }
        }

        sw.Write(dp[n] == int.MaxValue ? -1 : dp[n]);
    }
}