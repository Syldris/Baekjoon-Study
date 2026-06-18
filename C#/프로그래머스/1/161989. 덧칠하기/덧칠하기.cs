using System;

public class Solution
{
    public int solution(int n, int m, int[] section)
    {
        int answer = 0;

        bool[] paint = new bool[n + 1];
        Array.Fill(paint, true);
        for (int i = 0; i < section.Length; i++)
        {
            paint[section[i]] = false;
        }

        int num = -1;

        for (int i = 1; i <= n; i++)
        {
            if (i <= num) continue; // 이미 칠해졌음

            if (!paint[i])
            {
                num = i + m - 1; // i칸부터 m칸만큼 칠했으니 m-1칸까진 전부 칠해짐
                answer++;
            }
        }

        return answer;
    }
}