using System;
public class Solution
{
    public int solution(int[] d, int budget)
    {
        int answer = 0;

        Array.Sort(d); // 항상 작은 비용부터 처리하는것이 최적

        for (int i = 0; i < d.Length; i++)
        {
            if (budget >= d[i]) // 남은 돈이 충분하다면 지원.
            {
                budget -= d[i];
                answer++;
            }
            else break;
        }

        return answer;
    }
}