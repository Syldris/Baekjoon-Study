using System;
public class Solution
{
    public int solution(int[] numbers)
    {
        int answer = 0;

        bool[] arr = new bool[10];
        for (int i = 0; i < numbers.Length; i++)
        {
            int n = numbers[i];
            arr[n] = true;
        }

        for (int i = 0; i < 10; i++)
        {
            if (!arr[i])
                answer += i;
        }


        return answer;
    }
}