using System;

class Solution
{
    public int solution(int[] nums)
    {
        int answer = 0;

        int n = nums.Length;

        const int SIZE = 3000; // 1~1000 사이 숫자 3개이니 3000까지.
        bool[] isPrime = new bool[SIZE + 1];

        Array.Fill(isPrime, true);
        isPrime[0] = false;
        isPrime[1] = false;

        for (int i = 2; i * i <= SIZE; i++)
        {
            if (!isPrime[i]) continue; // 이미 소수가 아니면 i의 배수는 전부 소수가 아니게 제거되어있음.
            for (int j = 2; i * j <= SIZE; j++)
            {
                isPrime[i * j] = false;
            }
        }

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    int number = nums[i] + nums[j] + nums[k];
                    if (isPrime[number])
                        answer++;
                }
            }
        }

        return answer;
    }
}