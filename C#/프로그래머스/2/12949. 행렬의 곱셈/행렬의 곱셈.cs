using System;

public class Solution
{
    public int[,] solution(int[,] arr1, int[,] arr2)
    {
        int rSize = arr1.GetLength(0);
        int cSize = arr2.GetLength(1);

        int[,] answer = new int[rSize, cSize];

        // arr1 의 행요소 x arr2의 열요소

        // arr1 x arr2 = arr1 열 길이 = arr2 행 길이 여야함.
        // (행 1개의 원소 갯수) = 열 길이
        // (열 1개의 원소 갯수) = 행 길이 

        // 행렬곱 i j 에 대해서.
        // 첫번째 행렬의 i행과 두번째 행렬 j열을 곱한 원소 len개를 더한값이다.

        for (int r = 0; r < rSize; r++)
        {
            for (int c = 0; c < cSize; c++)
            {
                int value = 0;

                for (int i = 0; i < arr1.GetLength(1); i++)
                {
                    value += arr1[r, i] * arr2[i, c];
                }

                answer[r, c] = value;
            }
        }


        return answer;
    }
}