using System;
using System.Collections.Generic;
public class Solution
{
    public double[] solution(int k, int[,] ranges)
    {
        double[] answer = new double[ranges.GetLength(0)];

        List<int> rainList = new List<int>(); // 우박수열.
        rainList.Add(k);

        while ( k != 1)
        {
            if (k % 2 == 0)
                k /= 2;
            else
                k = k * 3 + 1;

            rainList.Add(k);
        }

        int n = rainList.Count - 1; // 구간 |0 ~ n| 이므로 수열길이-1 = n  

        for (int i = 0; i < ranges.GetLength(0); i++)
        { 
            int start = ranges[i, 0];
            int end = n + ranges[i, 1];

            double value = 0d;

            if (start > end)
            {
                answer[i] = -1; // 유효하지 않은 구간의 결과는 -1로 정의.
                continue;
            }

            for (int point = start; point < end; point++) // 끝점을 제하고. 시작점부터 i~i+1 구간의 넓이를 구하자.
            {
                // 사각형 모양으로 자를수있다. 가로는 1. 세로 y좌표는 각각 arr[point], arr[point+1] 곱하고 /2. 
                value += (double)(rainList[point] + rainList[point + 1]) / 2;  
            }

            answer[i] = value;
        }


        return answer;
    }
}