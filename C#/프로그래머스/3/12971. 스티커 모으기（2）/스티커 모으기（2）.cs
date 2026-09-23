using System;
using static System.Math;
class Solution
{
    public int solution(int[] sticker)
    {
        int answer = 0;
        int n = sticker.Length;

        if (n == 1) return sticker[0]; // n == 1 이면 n-2 인덱싱이 안되니 예외처리.

        int[,] dp = new int[n, 2];

        // [x, 0] = x번 스티커를 안쓴 상태
        // [x, 1] = x번 스티커를 쓴 상태

        dp[0, 1] = sticker[0]; // 0번 스티커를 사용한 상태로 시작.

        for (int i = 1; i < n - 1; i++) // 0번을 썻다면 마지막 스티커는 사용하지 못함.
        {
            dp[i, 0] = Max(dp[i - 1, 0], dp[i - 1, 1]); // 현재 스티커를 안쓰는 경우 이전 스티커 사용 X, O 모든 경우 가능.

            dp[i, 1] = dp[i - 1, 0] + sticker[i]; // 현재 스티커를 사용하는 경우 이전 스티커는 사용X 이여야함. 
        }

        answer = Max(dp[n - 2, 0], dp[n - 2, 1]); // n-1번 스티커까지 진행한뒤 n-1 스티커 쓰는경우, 안쓰는경우 MAX로 비교. 

        for (int i = 0; i < n; i++)
            for (int j = 0; j < 2; j++)
                dp[i, j] = 0;

        // 0번 스티커를 사용하지 않는 경우로 시작. 마지막 스티커까지 사용가능.
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = Max(dp[i - 1, 0], dp[i - 1, 1]);

            dp[i, 1] = dp[i - 1, 0] + sticker[i];
        }

        answer = Max(answer, Max(dp[n - 1, 0], dp[n - 1, 1])); // n번 스티커까지 진행한뒤 쓰는경우, 안쓰는경우 MAX로 비교. 

        return answer;
    }
}