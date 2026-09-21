using System;
class Solution
{
    public int solution(int n)
    {
        int answer = 0;

        // n => 0으로 역순서로 이동해서 계산.

        while (n != 0)
        {
            if (n % 2 == 0) // n/2 => n 순간이동 (비용 0)
                n /= 2;
            else // n-1 => n 점프 (비용 1)
            {
                n--;
                answer++;
            }
        }

        return answer;
    }
}