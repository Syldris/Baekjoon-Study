using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        bool[,] dp = new bool[n + 1, n + 1];
        for(int i = 1; i <= n; i++)
        {
            dp[i,i] = true;
        }

        for(int i = 1; i < n; i++)
        {
            if (arr[i - 1] == arr[i])
                dp[i, i + 1] = true;
        }

        for (int len = 2; len < n; len++)
        {
            for(int start = 0; start + len < n; start++)
            {
                int end = start + len;
                if (arr[start] == arr[end] && dp[start + 2,end])
                    dp[start + 1, end + 1] = true;
            }
        }

        int m = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            if (dp[start, end])
                sb.AppendLine("1");
            else
                sb.AppendLine("0");
        }


        Console.WriteLine(sb);
    }
}