using System;
using static System.Math;
public class Solution
{
    public long solution(int n)
    {
        int[] dp = new int[Math.Max(n + 1, 3)]; // 기본값 설정을 위해 3칸 이상은 보장.

        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = (dp[i - 1] + dp[i - 2]) % 1234567; // 1단계 전에서 1칸 오거나 2단계 전에서 2칸 뛰기 
        }

        return dp[n] ;
    }
}