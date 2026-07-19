using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] prices)
    {
        int n = prices.Length;
        int[] answer = new int[n];

        Stack<int> stack = new Stack<int>(); // 오름차순 단조스택.

        for (int i = 0; i < n; i++)
        {
            int value = prices[i];

            while (stack.Count > 0 && value < prices[stack.Peek()]) // 더 작은수가 오면 반복적으로 pop. 
            {
                int index = stack.Pop();
                answer[index] = i - index; // 안떨어진 시간 기록.
            }

            stack.Push(i);
        }

        while (stack.Count > 0) // 끝까지 가격이 떨어지지 않은 시점들 정리.
        {
            int index = stack.Pop();
            answer[index] = (n - 1) - index; 

        }

        return answer;
    }
}