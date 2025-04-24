using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int s = int.Parse(inputs[1]);

        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] dp = new int[n];

        dp[0] = arr[0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = dp[i - 1] + arr[i];
        }

        int start = 0, end = 0;
        int count = int.MaxValue;
        int number = 0;
        if (dp[n-1] < s)
        {
            Console.WriteLine(0);
            return;
        }

        while (start <= end && end < n)
        {

            if (start == 0)
                number = dp[end];
            else
                number = dp[end] - dp[start - 1];

            if(number >= s)
            {
                count = Math.Min(count, end - start + 1);
                start++;
            }
            else
            {
                end++;
            }
        }
        
        if (dp[n - 1] == s)
        {
            Console.WriteLine(s);
            return;
        }

        Console.WriteLine(count == int.MaxValue ? 0 : count);
    }
}
