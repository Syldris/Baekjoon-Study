using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            int input = int.Parse(Console.ReadLine());
            int[] dp = new int[Math.Max(input + 1, 4)];
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 4;
            for(int j = 4; j <= input; j++)
            {
                dp[j] = dp[j - 3] + dp[j - 2] + dp[j - 1];
            }
            Console.WriteLine(dp[input]);
        }
    }
}
