using System;

public class Solution
{
    public int solution(int distance, int[] rocks, int n)
    {
        int answer = 0;

        int start = 1, end = distance; // |시작점, 바위, 도착점| 지점사이의 거리 최소값을 이분탐색으로 좁히자.

        Array.Sort(rocks);

        while (start < end)
        {
            int mid = (start + end) / 2; // 시도해볼 지점사이 거리. mid+1를 기준삼아 성공하면 start를 mid+1. 실패시 end = mid

            int remove = n;

            int prevPos = 0; // 이전 위치.

            for (int i = 0; i < rocks.Length; i++)
            {
                if (rocks[i] - prevPos < mid + 1) // 지점 사이가 mid+1보다 작으면, 바위를 치우자 
                    remove--; // rock[i] 를 치웠으니 저장X

                else  // 아니라면 돌 위치 저장.     
                    prevPos = rocks[i];

                if (remove < 0) break; // 지울 횟수를 초과하면 조기종료.
            }

            if (distance - prevPos < mid + 1) // 끝점과 이전 지점 거리 비교.
                remove--;

            if (remove >= 0) // mid+1기준 성공했다면 start를 좁힘.
            {
                start = mid + 1;
            }
            else // mid+1을 실패했다면, end를 mid까지 좁혀 후보군에서 탈락시키고 재탐색.
            {
                end = mid;
            }
        }

        return start;
    }
}