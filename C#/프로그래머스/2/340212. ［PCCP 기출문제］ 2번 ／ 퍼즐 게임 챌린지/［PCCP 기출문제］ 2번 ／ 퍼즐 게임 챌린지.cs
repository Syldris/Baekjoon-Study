using System;

public class Solution
{
    public int solution(int[] diffs, int[] times, long limit)
    {
        int start = 1; // 양의 정수여야하니 최소 1.
        int end = 100000; // 퍼즐의 난이도는 최대 10만이므로 숙련도 10만초과는 의미X.

        while (start < end) // 이분탐색 
        {
            int mid = (start + end) / 2;

            long time = GameClearTime(mid, diffs, times, limit);

            if (time > limit) // 시간 초과시 mid를 => 로 밀어 레벨좀 올림.
            {
                start = mid + 1;
            }
            else if (time <= limit) // 시간 이하로 통과 가능하면 가능한만큼 mid를 <= 로 밀어서 최소 레벨로 통과.
            {
                end = mid;
            }
        }

        return start;
    }

    public long GameClearTime(int level, int[] diffs, int[] times, long limit)
    {
        long time = 0;
        int len = diffs.Length;

        for (int i = 0; i < len; i++)
        {
            if (level >= diffs[i]) // 숙련도가 충분하면 1번에 품.
            {
                time += times[i];
            }
            else
            {
                int wrongCount = diffs[i] - level; // 숙련도가 부족한 만큼 틀림. 

                if (i > 0) // 틀리면 이전 문제도 1번씩 다시품.
                    time += wrongCount * (times[i] + times[i - 1]); // 2*10^9 범위 안으로 들어올듯. 
                else // 0번 문제는 이전문제 없으니까 다시 풀게 없을듯.
                    time += wrongCount * times[i];

                time += times[i]; // 이후 해결.
            }
        }

        return time;
    }
}