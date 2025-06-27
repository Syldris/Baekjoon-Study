#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] dp = new int[n];
        dp[0] = int.MaxValue;
        for (int i = 1; i < n; i++)
        {
            dp[i] = arr[i] + arr[i-1];
        }

        sw.Write(dp.Min() * m);
    }
}
