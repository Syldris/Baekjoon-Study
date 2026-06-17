using System;

public class Solution
{
    public int solution(string t, string p)
    {
        int answer = 0;

        long value = long.Parse(p);

        for (int i = 0; i <= t.Length - p.Length; i++)
        {
            long num = long.Parse(t.Substring(i, p.Length));

            if (num <= value)
                answer++;
        }

        return answer;
    }
}