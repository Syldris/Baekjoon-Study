using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int[] answers)
    {
        int[] peoples = new int[3];

        // 3명이 아래 배열순서대로 반복해서 찍는다.
        int[] loop1 = { 1, 2, 3, 4, 5 };
        int[] loop2 = { 2, 1, 2, 3, 2, 4, 2, 5 };
        int[] loop3 = { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 };

        for (int i = 0; i < answers.Length; i++)
        {
            // 찍어서 맞추었는지 체크.
            if(answers[i] == loop1[i % loop1.Length]) peoples[0]++;
            if(answers[i] == loop2[i % loop2.Length]) peoples[1]++;
            if(answers[i] == loop3[i % loop3.Length]) peoples[2]++;

        }

        List<int> result = new List<int>();

        int maxAnswer = 0;
        for (int i = 0; i < 3; i++)
        {
            // 가장 많이 맞힌 사람이 바뀌면 초기화
            if (peoples[i] > maxAnswer)
            {
                maxAnswer = peoples[i];
                result.Clear();
                result.Add(i + 1);
            }
            else if(peoples[i]  == maxAnswer) // 동점자라면 추가
                result.Add(i + 1);
        }

        return result.ToArray();
    }
}