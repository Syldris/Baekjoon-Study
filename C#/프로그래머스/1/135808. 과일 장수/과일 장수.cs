using System;
using static System.Math;
public class Solution
{
    public int solution(int k, int m, int[] score)
    {
        int answer = 0;

        int totalBox = score.Length / m; // 사과 박스로 포장가능한 박스갯수

        Array.Sort(score, (a, b) => b.CompareTo(a)); // 값이 큰사과부터 같이 묶어서 파는게 항상 이득.

        for (int box = 0; box < totalBox; box++)
        {
            int min = k; // k가 최대 점수.
            for (int i = 0; i < m; i++) // m개 사과를 1개 박스로 포장.
            {
                min = Min(min, score[box * m + i]);
            }

            answer += min * m; // 점수 = m개 사과중 제일 낮은 점수 사과 x 갯수
        }
        return answer;
    }
}