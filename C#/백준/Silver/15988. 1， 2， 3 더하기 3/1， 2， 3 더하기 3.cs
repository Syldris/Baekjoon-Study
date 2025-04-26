using System;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        ulong[] dp = new ulong[1000001];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 4;
        for (int i = 4; i <=1000000; i++)
        {
            dp[i] = (dp[i - 1] + dp[i - 2] + dp[i - 3]) % 1000000009;
        }
        for (int i = 0; i < t ; i++)
        {
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine(dp[index]);
        }
    }
}
