using System;
using System.Text;
using System.IO;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            int r = int.Parse(line[0]);
            int c = int.Parse(line[1]);
            arr[i] = r;
            arr[i + 1] = c;
        }

        long[,] dp = new long[n, n];
        for (int len = 1; len < n; len++)
        {
            for (int i = 0; i < n - len; i++)
            {
                int j = i + len;
                dp[i,j] = long.MaxValue;

                for (int v = i; v < j; v++)
                {
                    long value = dp[i, v] + dp[v + 1, j] + arr[i] * arr[v + 1] * arr[j + 1];
                    dp[i,j] = Math.Min(value, dp[i,j]);
                }
            }
        }
        Console.WriteLine(dp[0, n - 1]);
    }
}
