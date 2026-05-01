using System;
public struct Score
{
    public int num;
    public int x;

    public Score(int num, int x)
    {
        this.num = num;
        this.x = x;
    }
}

public class Solution
{
    public int[] solution(int target)
    {
        // dp[점수] 던진 횟수, 싱글 불 갯수.
        Score[] dp = new Score[target + 1];

        for (int i = 1; i <= target; i++)
            dp[i] = new Score(int.MaxValue, 0);

        for (int i = 0; i < target; i++)
        {
            for (int j = 1; j <= 20; j++)
            {
                // j점 짜리 싱글던지기.
                if (i + j <= target)
                    OverWrite(ref dp[i + j], new Score(dp[i].num + 1, dp[i].x + 1));

                // j점 짜리 더블던지기.
                if (i + j * 2 <= target)
                    OverWrite(ref dp[i + j * 2], new Score(dp[i].num + 1, dp[i].x));

                // j점 짜리 트리플던지기.
                if (i + j * 3 <= target)
                    OverWrite(ref dp[i + j * 3], new Score(dp[i].num + 1, dp[i].x));
            }

            if (i + 50 <= target)
            {
                // 50점 짜리 던졌다면 던진횟수+1 싱글불 갯수+1 이랑 비교.
                OverWrite(ref dp[i + 50], new Score(dp[i].num + 1, dp[i].x + 1));
            }
        }


        // 다트수와 싱글,불 갯수 반환
        int[] answer = new int[2] { dp[target].num, dp[target].x };

        return answer;
    }
    // 덮어 쓰기.

    void OverWrite(ref Score main, Score sub)
    {
        if (sub.num < main.num) // 던진 횟수가 더 적다면 갱신.
        {
            main.num = sub.num;
            main.x = sub.x;
        }
        else if (main.num == sub.num && sub.x > main.x) // 던진횟수가 같고 싱글 불 갯수가 많다면 갱신.
        {
            main.num = sub.num;
            main.x = sub.x;
        }
    }
}