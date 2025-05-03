using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int[] memoryArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] costArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int[] dp = new int[10001];

        for (int i = 0; i < n; i++)
        {
            for (int j = 10000; j >= costArr[i]; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - costArr[i]] + memoryArr[i]);
            }
        }

        for (int i = 0; i <= 10000; i++)
        {
            if (dp[i] >= m)
            {
                Console.WriteLine(i);
                return;
            }
        }
    }
}