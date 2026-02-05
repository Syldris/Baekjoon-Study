using System;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] dp = new int[count];


        for (int i = 0; i < count; i++)
        {
            dp[i] = 1;
            for(int j = 0; j < i; j++)
            {
                if(arr[j] <arr[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        Console.WriteLine(dp.Max());
    }
}
