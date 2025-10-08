#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        long[] dp = new long[n+1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = i * dp[i - 1];
        }
        sw.Write(dp[n]);
    }
}