using System;
public class Solution
{
    public int solution(int[,] info, int n, int m)
    {
        int[] dp = new int[m]; // B가 i만큼 훔쳤을때 N의 최소 흔적값.

        const int MAX = int.MaxValue / 2;
        Array.Fill(dp, MAX);
        dp[0] = 0;


        int len = info.GetLength(0);

        for (int i = 0; i < len; i++)
        {
            int curN = info[i, 0];
            int curM = info[i, 1];

            for (int j = m - 1; j >= 0; j--)
            {
                if (j + curM < m) // M을 넘기면 안됨. 또한 초기화 된 부분만 진행.
                {
                    dp[j + curM] = Math.Min(dp[j], dp[j + curM]); // M이 훔치는 경우
                }

                dp[j] = dp[j] + curN; // N이 훔치는 경우
            }
        }

        int answer = MAX;

        for (int i = 0; i < dp.Length; i++)
        {
            answer = Math.Min(dp[i], answer);
        }

        if (answer >= n)
            answer = -1;

        return answer;
    }
}