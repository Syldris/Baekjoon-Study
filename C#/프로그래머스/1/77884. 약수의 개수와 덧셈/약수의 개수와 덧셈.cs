using System;

public class Solution
{
    public int solution(int left, int right)
    {
        int answer = 0;
        int[] factors = new int[1001];

        for (int i = 1; i <= 1000; i++)
        {
            for (int j = 1; i * j <= 1000; j++)
            {
                factors[i * j]++;
            }
        }

        for (int i = left; i <= right; i++)
        {
            if (factors[i] % 2 == 0) // 약수 갯수 짝수면 더하고
                answer += i;
            else
                answer -= i; // 아니면 뺌
        }

        return answer;
    }
}