using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    public int solution(int N, int number)
    {
        // [N을 사용한 횟수] = {값 집합.}
        HashSet<int>[] dp = new HashSet<int>[9];
        for (int i = 1; i <= 8; i++) // 최대 8번까지 사용가능.
            dp[i] = new HashSet<int>();

        dp[1].Add(N); // 1번 사용

        int trickNumber = N;

        for (int i = 2; i <= 8; i++) // i = 사용횟수
        {
            trickNumber = trickNumber * 10 + N;
            dp[i].Add(trickNumber); // N을 i개 이어붙인수 추가.

            for (int j = 1; j < i; j++) // dp[i] 가짓수는 i = x + j 방법으로 만들면 됨. 
            {
                int x = i - j; // 합이 i가 되게끔.

                foreach (var a in dp[x])
                {
                    foreach (var b in dp[j])
                    {
                        if (b == 0) continue; // 0 나누기 예외처리.
                        dp[i].Add(a + b);
                        dp[i].Add(a - b);
                        dp[i].Add(a * b);
                        dp[i].Add(a / b);
                    }
                }
            }
        }

        for (int i = 1; i <= 8; i++)
        {
            if (dp[i].Contains(number))
                return i;
        }

        return -1;

    }
}