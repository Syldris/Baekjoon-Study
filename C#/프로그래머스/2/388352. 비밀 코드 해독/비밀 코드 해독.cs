using System;

public class Solution
{
    int answer = 0;
    int n = 0;
    int m = 0;

    int[] arr = new int[31]; // 5개의 고정 배열. n <= 30 이니 완탐 최대 30^5

    public int solution(int n, int[,] q, int[] ans)
    {
        this.n = n;
        m = q.GetLength(0);

        BackTrack(0, q, ans, 0);
        return answer;
    }

    void BackTrack(int depth, int[,] q, int[] ans, int prev)
    {
        if (depth == 5)
        {
            bool pass = true;

            for (int i = 0; i < m; i++)
            {
                int passWordMatch = 0; // 현재코드랑 q랑 일치갯수.

                for (int j = 0; j < 5; j++)
                {
                    int number = q[i, j];
                    if (arr[number] > 0)
                        passWordMatch++;
                }

                if (passWordMatch != ans[i]) // 실제 갯수와 다르면 실패.
                {
                    pass = false;
                    break;
                }
            }

            if (pass) answer++; // 모든 q에 대해서 시스템 응답과 일치하면 가능.

            return;
        }

        for (int i = prev + 1; i <= n; i++)
        {
            arr[i]++;
            BackTrack(depth + 1, q, ans, i);
            arr[i]--;
        }
    }
}