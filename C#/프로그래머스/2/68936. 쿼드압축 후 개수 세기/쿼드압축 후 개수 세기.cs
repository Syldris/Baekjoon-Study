using System;
public class Solution
{
    int zeroValue;
    int oneValue;

    public int[] solution(int[,] arr)
    {
        int size = arr.GetLength(0);
        Solve(0, 0, size, arr);

        return new int[2] { zeroValue, oneValue };
    }

    void Solve(int row, int col, int size, int[,] arr) // 분할정복
    {
        int zero = 0;
        int one = 0;

        for (int y = row; y < row + size; y++)
        {
            for (int x = col; x < col + size; x++)
            {
                if (arr[y, x] == 0)
                    zero++;
                else
                    one++;
            }
        }

        // 0 혹은 1만 있다면 압축완료
        if (zero == 0)
        {
            oneValue++;
            return;
        }
        else if (one == 0)
        {
            zeroValue++;
            return;
        }

        int half = size / 2;

        // 4개구역으로 분할

        Solve(row, col, half, arr); // 좌상단
        Solve(row + half, col, half, arr); // 좌하단

        Solve(row, col + half, half, arr); // 우상단
        Solve(row + half, col + half, half, arr); // 우하단
    }
}