using System;
using static System.Math;
public class Solution
{
    int answer = 0;
    int n;

    const int SIZE = 10000000;

    bool[] isPrime = new bool[SIZE];

    public int solution(string numbers)
    {
        n = numbers.Length;

        bool[] select = new bool[n];

        Array.Fill(isPrime, true);
        isPrime[0] = false;
        isPrime[1] = false;

        for (int i = 2; i <= Math.Sqrt(SIZE); i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j < SIZE; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        DFS(0, select, numbers);

        return answer;
    }

    void DFS(int value, bool[] select, string number)
    {
        if (isPrime[value])
        {
            isPrime[value] = false;
            answer++;
        }

        for (int i = 0; i < n; i++)
        {
            if (!select[i])
            {
                int x = number[i] - '0';

                select[i] = true;
                DFS(value * 10 + x, select, number);
                select[i] = false;
            }
        }
    }
}