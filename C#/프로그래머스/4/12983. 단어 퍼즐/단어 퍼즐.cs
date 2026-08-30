using System;
using static System.Math;
public class Solution
{
    public int solution(string[] strs, string t)
    {
        // 왼쪽부터 차례대로 완성시킬때 
        // [완성된글자] = 단어 조각 사용갯수 dp[4] = bana|na  
        int[] dp = new int[t.Length + 1];
        Array.Fill(dp, int.MaxValue / 2);
        dp[0] = 0; // 미완성은 큰값으로 채우고 0글자 0으로 시작.

        for (int i = 1; i <= t.Length; i++)
        {
            foreach (var str in strs)
            {
                int len = str.Length;
                if (len > i) continue;

                // str 글자로 채워서 dp[i]까지의 단어 조각 사용갯수를 줄일수있는지 체크.
                // span으로 잘라서 i-len부터 len개 메모리 자르고 str과 같은지 함수로 비교.
                if (dp[i - len] + 1 < dp[i] && t.AsSpan(i - len, len).SequenceEqual(str))
                {
                    dp[i] = dp[i - len] + 1; // i-len ~ i 까지 str조각으로 채워서 1조각 채움.
                }
            }
        }

        return dp[t.Length] == int.MaxValue / 2 ? -1 : dp[t.Length];
    }
}