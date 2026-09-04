using System;

public class Solution
{
    public long solution(int k, int d)
    {
        long answer = 0;

        long[] arr = new long[d + 1];
        for (long i = 1; i <= d; i++)
            arr[i] = i * i;

        // d 거리까지 점을찍을건데, d^2 = x^2 + y^2 로 두자.

        long distance = (long)d * d;

        for (long x = 0; x <= d; x += k)
        {
            long value = x * x;

            int start = 0;
            int end = d;

            while (start < end)
            {
                int mid = (start + end) / 2;

                // 조건 만족시 start = mid+1 이니 mid+1으로 조건을 검사해서 start를 항상 유효하게 유지.

                if (arr[mid + 1] + value <= distance) // x^2+y^2 <= d^2 이라면 y를 늘리는 쪽으로 
                {
                    start = mid + 1; // start => 방향으로.
                }
                else // end <= 방향으로 축소.
                {
                    end = mid;
                }
            }


            // start까지 y좌표 가능. 0부터 점을찍고 k 만큼 떨어져서 찍으므로,
            answer += start / k + 1; // x 좌표에 대해서 y축 점 갯수.
        }

        return answer;
    }
}