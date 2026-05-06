using System;
public class Solution
{
    public int solution(int[] players, int m, int k)
    {
        int answer = 0;

        int curServer = 1;

        int[] serverOff = new int[24]; // 서버 꺼지는 시간 기록.

        for (int i = 0; i < 24; i++)
        {
            curServer -= serverOff[i];

            int number = players[i];

            if (number >= curServer * m)
            {
                int newServer = number / m + 1;

                int diff = newServer - curServer;
                curServer += diff;

                answer += diff;

                if (i + k < 24)
                    serverOff[i + k] = diff;
            }
        }

        return answer;
    }
}