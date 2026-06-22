using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] queue1, int[] queue2)
    {
        int answer = 0;
        int n = queue1.Length;

        Queue<int> Queue1 = new Queue<int>();
        Queue<int> Queue2 = new Queue<int>();

        long value1 = 0;
        long value2 = 0;
        for (int i = 0; i < n; i++)
        {
            value1 += queue1[i];
            value2 += queue2[i];

            Queue1.Enqueue(queue1[i]);
            Queue2.Enqueue(queue2[i]);
        }

        while (value1 != value2 && answer < n * 8) // 실제 Max 교환횟수는 어느정도 일까? 
        {
            answer++;
            if (value1 > value2)
            {
                int pop = Queue1.Dequeue();
                value1 -= pop;
                Queue2.Enqueue(pop);
                value2 += pop;
            }
            else
            {
                int pop = Queue2.Dequeue();
                value2 -= pop;
                Queue1.Enqueue(pop);
                value1 += pop;
            }
        }

        return answer < n * 8 ? answer : -1;
    }
}