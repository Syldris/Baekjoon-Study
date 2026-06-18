using System;
public class Solution
{
    public int solution(int n, int m, int[] section)
    {
        int answer = 0;

        int num = -1;

        for (int i = 0; i < section.Length; i++)
        {
            if (section[i] <= num) continue; // 이미 칠해졌음

            num = section[i] + m - 1; // i칸부터 m칸만큼 칠했으니 m-1칸까진 전부 칠해짐
            answer++;
        }

        return answer;
    }
}