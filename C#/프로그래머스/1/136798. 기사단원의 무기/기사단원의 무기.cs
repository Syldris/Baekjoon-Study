using System;

public class Solution
{
    public int solution(int number, int limit, int power)
    {
        int answer = 0;

        int[] factor = new int[number + 1]; // factor[x] = x의 약수 개수

        for (int i = 1; i <= number; i++)
            for (int j = i; j <= number; j += i) // i의 배수인 j는 i를 약수로 가짐.
                factor[j]++;

        for (int i = 1; i <= number; i++)
        {
            if (factor[i] > limit) // 리미트 초과면 power 만큼을 조정.
                answer += power;
            else
                answer += factor[i];
        }

        return answer;
    }
}