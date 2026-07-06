using System;

public class Solution
{
    public int[] solution(int n, long left, long right)
    {
        long size = right - left + 1;
        int[] answer = new int[size];

        /* 1 2 3 4 5 // 1번째줄 1이 1번 반복. 이후 순차
         * 2 2 3 4 5 // 2번째쭐 2가 2번 반복.
         * 3 3 3 4 5 // 3번째줄 3가 3번 반복.
         * 4 4 4 4 5 // 위와 같음
         * 5 5 5 5 5 // n번째 줄은 n 번 반복임을 알 수 있다.
         */

        // 시작 위치 지정.

        int x = (int)(left % n); // 줄 만들고 남은 나머지가 가로 위치.
        int y = (int)(left / n); // 0부터 시작해 n번쨰마다 새줄.

        for (int i = 0; i < size; i++)
        {
            if (x <= y) // n번째 줄에선 n번까지 같은 숫자 반복 
            {
                answer[i] = y + 1; // 0-index => 1-index
            }
            else
            {
                answer[i] = x + 1; // n번째 초과 부분에선 x축 위치가 곧 숫자.
            }

            x++;
            if (x == n) // 새줄로 변경
            {
                y++;
                x = 0;
            }
        }


        return answer;
    }
}