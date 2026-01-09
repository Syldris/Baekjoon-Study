#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int money = input[0];
        int year = input[1];

        int[] dp = new int[year + 1];
        dp[0] = money;
        for (int i = 1; i <= year; i++)
        {
            if (i >= 5)
                dp[i] = Math.Max(dp[i - 5] * 135 / 100, dp[i]);

            if (i >= 3)
                dp[i] = Math.Max(dp[i - 3] * 120 / 100, dp[i]);

            dp[i] = Math.Max(dp[i - 1] * 105 / 100, dp[i]);
        }

        sw.Write(dp[year]);
    }
}