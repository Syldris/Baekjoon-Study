using System;

public class Solution
{
    public int solution(int[] schedules, int[,] timelogs, int startday)
    {
        int answer = 0;

        int n = schedules.Length;

        for (int i = 0; i < n; i++)
        {
            bool success = true;
            int workHour = schedules[i] / 100;
            int workMin = schedules[i] % 100 + 10; // 10분 지각까지 허용.

            if (workMin >= 60)
            {
                workHour++;
                workMin -= 60;
            }

            for (int j = 0; j < 7; j++)
            {
                int day = (startday + j) % 7;

                if (day == 6 || day == 0) // 토, 일요일은 영향 X
                    continue;

                int hour = timelogs[i, j] / 100;
                int min = timelogs[i, j] % 100;

                // 지각하면 실패.
                if (hour > workHour || (hour == workHour && min > workMin))
                {
                    success = false;
                    break;
                }
            }

            if (success) answer++;
        }

        return answer;
    }
}