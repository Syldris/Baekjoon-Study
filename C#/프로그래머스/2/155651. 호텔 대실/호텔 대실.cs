using System;

public class Solution
{
    public int solution(string[,] book_time)
    {
        int answer = 0;

        int size = 60 * 24; // 24시간. 

        // 차분배열 트릭. 들어오는 시점에 +1 나가는 시점에 -1 기록
        // 이후 누적합처러 쭉 밀면 된다.
        int[] diff = new int[size];

        for (int i = 0; i < book_time.GetLength(0); i++)
        {
            string[] startSpilt = book_time[i, 0].Split(':');
            string[] endSpilt = book_time[i, 1].Split(':');

            int startMin = int.Parse(startSpilt[0]);
            int startSec = int.Parse(startSpilt[1]);

            int endMin = int.Parse(endSpilt[0]);
            int endSec = int.Parse(endSpilt[1]);

            // 들어올때 +1 나갈때 -1 인원 기록.
            diff[startMin * 60 + startSec]++;

            if (endMin * 60 + endSec + 10 < size) // 청소시간 포함 24시를 넘을 수 있으니 체크
                diff[endMin * 60 + endSec + 10]--; // 사용한 방은 10분동안 청소하므로 객실은 10분 뒤에 자리생김.

            // 추가로 시작시간은 종료시간보다 빠르니 시작 23시 종료 2시같은 경우는 없음.
        }

        // 시간별로 몇명이 있었는지 체크.
        int[] time = new int[size];

        time[0] = diff[0];

        for (int i = 1; i < size; i++)
        {
            // 이전 타임를 참고해서 인원차이를 합산해서 현재 타임 인원계산.
            time[i] = time[i - 1] + diff[i];

            answer = Math.Max(answer, time[i]);
        }

        return answer;
    }
}