using System;

public class Solution
{
    public int solution(int[] citations)
    {
        int answer = 0;

        Array.Sort(citations, (a, b) => b.CompareTo(a)); // 내림차순 정렬

        for (int i = 1; i <= citations.Length; i++)
        {
            int value = citations[i - 1];

            value = Math.Min(value, i);

            answer = Math.Max(answer, value);
        }

        return answer;
    }
}