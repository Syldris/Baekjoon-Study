using System;
using static System.Math;
public class Solution
{
    public long solution(int a, int b, int[] g, int[] s, int[] w, int[] t)
    {
        long answer = 0;

        int n = g.Length;

        // 이분탐색
        long start = 0;
        long end = long.MaxValue / 100;

        while (start < end)
        {
            long mid = (start + end) / 2;

            long totalOre = 0;
            long totalGold = 0;
            long totalSilver = 0;

            for (int i = 0; i < n; i++)
            {
                long move = (mid / t[i] + 1) / 2; // 운반 이동 횟수. (편도+1) / 2

                long ore = Min(g[i] + s[i], w[i] * move); // 획득 가능한 광물 수. min(광물량, 채굴량)
                long gold = Min(g[i], w[i] * move); // 획득 가능한 금.
                long silver = Min(s[i], w[i] * move); // 획득 가능한 은.

                totalOre += ore;
                totalGold += gold;
                totalSilver += silver;
            }

            if (!(totalOre >= a + b && totalGold >= a && totalSilver >= b))
            {
                start = mid + 1;
            }
            else
            {
                end = mid;
            }
        }


        return start;
    }
}