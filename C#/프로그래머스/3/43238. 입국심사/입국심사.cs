using System;

public class Solution
{
    public long solution(int n, int[] times)
    {
        // 이분탐색으로 몇분에 심사 다받을수있는지 체크하면 된다.
        long start = 1;
        long end = long.MaxValue - 1;

        while (start < end)
        {
            long mid = (start + end) >> 1; // 시간 기준점.

            long people = 0;

            foreach (var item in times)
            {
                people += mid / item; // 받을수있는 사람 체크.
                if(people >= n) break;
            }

            if (people >= n) // n명이상 심사가 가능하면 오른쪽 end범위를 줄여서 값을 줄여 재탐색.  
            {
                end = mid;
            }
            else // 반대로 n명을 시간안에 다 심사 못하면 왼쪽 start를 증가시켜 값을 늘려서 재탐색.
            {
                start = mid + 1;
            }

        }

        // 이분탐색은 mid == 조건일때 처리가 중요한데 
        // 만족하는 값이상 Lower 탐색은 같을때 왼쪽으로 가서 첫 이상 위치를 반환하고
        // 만족하는 값초과 Upper 탐색은 오른쪽으로 첫 초과위치를 반환함.

        // 2 |5 5 5| 6 일때 lower는 같을때 <=로 가서 인덱스1 Upeer는 4를 반환

        return start;
    }
}