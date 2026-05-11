using System;
using System.Collections.Generic;
using System.Text;
public class Solution
{
    public string solution(string number, int k)
    {
        Stack<char> stack = new Stack<char>();

        stack.Push(number[0]); // 첫자리 일단 넣고 시작.

        for (int i = 1; i < number.Length; i++)
        {
            char num = number[i];

            // 제거 할 수 k와 스택이 0 초과여야함.
            // 현재 받은 수가 본인 앞자리보다 크다면 제거하고 
            // 본인이 들어가는게 이득.
            // 수를 크게 만들거라면 앞에서부터 하는게 항상 이득.
            while (k > 0 && stack.Count > 0 && num > stack.Peek())
            {
                stack.Pop();
                k--;
            }

            // 받은 순서대로 추가.
            stack.Push(num);
        }

        while (k > 0) // 9 8 7 6 등으로 들어와서 k가 소모되지 않았다면..
        {
            stack.Pop(); // 제일 작은 뒷자리 수 제거하면서 k 소모
            k--;
        }

        char[] result = new char[stack.Count]; 
        for (int i = stack.Count - 1; i >= 0; i--) // 1 2 3 4 면 스택에는 4 3 2 1 역순이므로 역순저장
        {
            result[i] = stack.Pop();
        }

        StringBuilder sb = new StringBuilder(); // string 반복 조작.

        for (int i = 0; i < result.Length; i++)
        {
            sb.Append(result[i]);
        }

        return sb.ToString();
    }
}