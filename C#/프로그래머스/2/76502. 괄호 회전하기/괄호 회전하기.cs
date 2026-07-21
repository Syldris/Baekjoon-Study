using System;
using System.Collections.Generic;
public class Solution
{
    public enum Brackets
    {
        Small,
        Middle,
        Big
    }

    public int solution(string s)
    {
        int answer = 0;

        Queue<char> queue = new Queue<char>();
        Stack<Brackets> stack = new Stack<Brackets>();

        for (int startIndex = 0; startIndex < s.Length; startIndex++)
        {
            // 소/중/대 괄호 열려있는 갯수.
            int small = 0;
            int middle = 0;
            int big = 0;

            bool isValid = true;

            for (int i = startIndex; i < s.Length; i++)
            {
                queue.Enqueue(s[i]);
            }
            for (int j = 0; j < startIndex; j++)
            {
                queue.Enqueue(s[j]);
            }

            while (queue.Count > 0)
            {
                char c = queue.Dequeue();

                switch (c)
                {
                    case '(':
                        small++;
                        stack.Push(Brackets.Small); break;
                    case '{':
                        middle++;
                        stack.Push(Brackets.Middle); break;
                    case '[':
                        big++;
                        stack.Push(Brackets.Big); break;

                    // 괄호를 닫을땐 열린 괄호가 1개 이상이여야 하고 이전 열린 괄호와 같아야함.
                    case ')':
                        small--;
                        if (small < 0 || stack.Pop() != Brackets.Small)
                        {
                            isValid = false;
                            queue.Clear();
                        } break;
                    case '}':
                        middle--;
                        if (middle < 0 || stack.Pop() != Brackets.Middle)
                        {
                            isValid = false;
                            queue.Clear();
                        }
                        break;
                    case ']':
                        big--;
                        if (big < 0 || stack.Pop() != Brackets.Big)
                        {
                            isValid = false;
                            queue.Clear();
                        }
                        break;

                }
            }

            if (isValid && small == 0 && middle == 0 && big == 0) // 모든 괄호가 다 닫혀있어야 함.
                answer++;
        }

        return answer;
    }
}