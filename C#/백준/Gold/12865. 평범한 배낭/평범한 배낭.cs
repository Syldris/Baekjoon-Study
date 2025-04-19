using System;
using System.Collections;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int k = int.Parse(inputs[1]);
        int[] dp = new int[k + 1];

        for (int i = 1; i <= n; i++)
        {
            string[] line = Console.ReadLine().Split();
            int weight = int.Parse(line[0]);
            int money = int.Parse(line[1]);

            for (int j = k; j >= weight; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - weight] + money);
            }
        }

        Console.WriteLine(dp[k]);
    }
}
