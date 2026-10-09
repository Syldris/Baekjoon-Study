using System;
using System.Text;
public class Solution
{
    public string solution(int[] food)
    {
        StringBuilder answer = new StringBuilder();

        for (int i = 1; i < food.Length; i++)
        {
            answer.Append((char)('0' + i), food[i] / 2);
        }

        answer.Append(0);

        for (int i = food.Length - 1; i > 0; i--)
        {
            answer.Append((char)('0' + i), food[i] / 2);
        }

        return answer.ToString();
    }
}