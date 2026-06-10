using System;
public class Solution
{
    public int solution(int x, int y, int n)
    {
        const int MAX = 1000000;

        int[] dp = new int[MAX + 1];
        Array.Fill(dp, MAX); // MAX로 채워서 최대비용으로 둠.

        dp[x] = 0; // 시작부분만 0
        for (int i = 1; i <= MAX; i++)
        {
            if (dp[i] == MAX) // MAX면 접근불가.
                continue;

            if (i + n <= MAX)
                dp[i + n] = Math.Min(dp[i] + 1, dp[i + n]);

            if (i * 2 <= MAX)
                dp[i * 2] = Math.Min(dp[i] + 1, dp[i * 2]);

            if (i * 3 <= MAX)
                dp[i * 3] = Math.Min(dp[i] + 1, dp[i * 3]);
        }


        return dp[y] == MAX ? -1 : dp[y];
    }
}