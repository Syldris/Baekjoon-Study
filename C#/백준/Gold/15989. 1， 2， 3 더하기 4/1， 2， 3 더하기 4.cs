using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        int[] dp = new int[10001];
        dp[0] = 1;
        for(int i = 1; i <= 3;  i++)
        {
            for (int j = i; j <= 10000; j++)
            {
                dp[j] += dp[j - i];
            }
        }

        for (int i = 0; i < t; i++)
        {
            int value = int.Parse(Console.ReadLine());
            Console.WriteLine(dp[value]);
        }
    }
}
