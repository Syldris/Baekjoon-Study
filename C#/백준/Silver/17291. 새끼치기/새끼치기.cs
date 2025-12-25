#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] dp = new int[21];

        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 4;
        dp[4] = 7;
        for (int i = 5; i <= n; i++)
        {
            dp[i] = dp[i - 1] * 2;
            if (i % 2 == 0)
            {
                dp[i] = dp[i] - dp[i - 4] - dp[i - 5];
            }
        }

        sw.Write(dp[n]);
    }
}