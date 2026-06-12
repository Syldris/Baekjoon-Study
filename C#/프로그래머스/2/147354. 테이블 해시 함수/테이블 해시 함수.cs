using System;

public class Solution
{
    public int solution(int[,] data, int col, int row_begin, int row_end)
    {
        int n = data.GetLength(0);

        int[] sorted = new int[n]; // [index] = 원본 배열 인덱스, 로 두고 기준점 정렬후에 원본배열 찾기.

        for (int i = 0; i < n; i++)
        {
            sorted[i] = i;
        }

        col--; // 1-index => 0-index

        Array.Sort(sorted, (a, b) =>
        {
            if (data[a, col] != data[b, col]) // col번째 값 기준 오름차순.
            {
                return data[a, col].CompareTo(data[b, col]);
            }
            else // 같으면 1번째 값 기준 내림차순.
                return data[b, 0].CompareTo(data[a, 0]);
        });

        int answer = 0;

        int len = data.GetLength(1);

        for (int i = row_begin; i <= row_end; i++)
        {
            int value = 0;
            int index = sorted[i - 1]; // 1-index => 0-index + 정렬후 i번째 위치에 있는 원본 배열 인덱스.

            for (int j = 0; j < len; j++)
            {
                value += data[index, j] % i;
            }
            answer ^= value; // 누적 Xor.
        }

        return answer;
    }
}