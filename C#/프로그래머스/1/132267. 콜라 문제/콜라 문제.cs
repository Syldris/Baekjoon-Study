using System;

public class Solution
{
    public int solution(int a, int b, int n)
    {
        int answer = 0;

        while (n >= a) // 빈병으로 콜라 받을수 있다면, 반복
        {
            int cola = (n / a) * b; // a개빈 병 묶음을 콜라 b개로 모두 환전
            answer += cola;

            n = (n % a) + cola; // 남은 빈병에 받은 콜라갯수 더함.
        }

        return answer;
    }
}