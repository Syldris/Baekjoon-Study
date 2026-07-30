using System;

class Solution
{
    public int solution(int n, int a, int b)
    {
        int answer = 0;

        while (a != b) // a와 b가 대전을 치르면 나눈 뒤 같아짐
        {
            // (1,2) 1번 (3,4) 2번 이 되게끔 +1 후 /2로 나눔.

            a = (a + 1) / 2;
            b = (b + 1) / 2;

            answer++;
        }

        return answer;
    }
}