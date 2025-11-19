#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = arr[i];
            for (int j = i+1; j < n; j++)
            {
                dp[i, j] = dp[i, j - 1] * arr[j];
            }
        }
        int result = 0;

        for (int a = 0; a < n; a++)
        {
            for (int b = a+1; b < n; b++)
            {
                for (int c = b+1; c < n; c++)
                {
                    for (int d = c+1; d < n; d++)
                    {
                        int value = dp[0, a] + dp[a + 1, b] + dp[b + 1, c] + dp[c + 1, d];
                        result = Math.Max(result, value);
                    }
                }
            }
        }

        sw.Write(result);
    }
}