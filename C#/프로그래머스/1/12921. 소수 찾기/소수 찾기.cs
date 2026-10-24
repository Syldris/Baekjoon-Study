using System;
public class Solution
{
    public int solution(int n)
    {
        int answer = 0;
        bool[] isPrime = new bool[n + 1];
        Array.Fill(isPrime, true);

        for (int i = 2; i * i <= n; i++) // 합성수를 걸러낼때 x = i*j 로 걸러내니까, i*i 지점까지만 체크해도 된다. 
        {
            for (int j = 2; i * j <= n; j++) // i * j <= n 까지.
            {
                isPrime[i * j] = false;
            }
        }

        for (int i = 2; i <= n; i++)
            if (isPrime[i]) answer++;

        return answer;
    }
}