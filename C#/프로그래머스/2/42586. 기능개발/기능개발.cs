using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> answer = new List<int>(); // 배포마다 몇개의 기능이 등록되는지.

        int n = progresses.Length;
        int day = 0; // 지난 날짜.

        int value = 0; // 작업한 갯수.

        for (int i = 0; i < n; i++)
        {
            // 일해야 하는양 = 100% - 시작진도 + 진행속도*날짜
            int work = 100 - (progresses[i] + speeds[i] * day);

            if (work > 0) // 일을 추가로 더해야할떄.
            {
                if (value != 0)
                {
                    answer.Add(value); // 날짜 바꾸기 전에 처리한 작업 갯수 등록.
                    value = 0;
                }

                day += work / speeds[i];
                if (work % speeds[i] != 0)
                    day++;
            }

            value++;
        }

        answer.Add(value); // 마지막 몇개 기능 배포되는지 기록.

        return answer.ToArray();
    }
}