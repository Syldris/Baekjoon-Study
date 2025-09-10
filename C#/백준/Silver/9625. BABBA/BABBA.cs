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
        (int a, int b)[] dp = new (int, int)[n + 1];


        dp[1] = (0, 1);
        for (int i = 2; i <= n; i++)
        {
            dp[i] = (dp[i - 1].b, dp[i - 1].a + dp[i - 1].b);
        }
        sw.Write($"{dp[n].a} {dp[n].b}");

    }
}
