using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] numbers)
    {
        int n = numbers.Length;
        int[] answer = new int[n];

        Array.Fill(answer, -1); // 기본값은 없으면 -1.

        // 단조스택을 쓰자.
        // 내림차순으로 5 2 1 식으로 단조로 저장하다가
        // 4 들어오면 1 2 는 pop하고 5 4만 남겨두면서 기억.
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            // 현재 스택끝(제일 작은값)보다 크면 pop.
            // 자신보다 뒤에있고 크면서 가장 가까이 있는수를 만족.

            // 인덱스 형식으로 저장하니 꺼내와서 비교.
            while (stack.Count > 0 && numbers[stack.Peek()] < numbers[i])
            {
                int index = stack.Pop();
                answer[index] = numbers[i]; // 뒤에 나오는 큰수가 무엇인지 기록.
            }
            stack.Push(i);
        }

        return answer;
    }
}