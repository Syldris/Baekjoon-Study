using System;
using System.Collections.Generic;
using static System.Math;

public class Solution
{
    public int[] solution(int rows, int columns, int[,] queries)
    {
        int n = queries.GetLength(0);
        int[] answer = new int[n];

        int[,] board = new int[columns, rows];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                board[x, y] = y * columns + x + 1;
            }
        }


        for (int i = 0; i < n; i++)
        {
            List<(int number, int x, int y)> list = new List<(int, int, int)>();

            // 1-index => 0-index
            int y1 = queries[i, 0] - 1;
            int x1 = queries[i, 1] - 1;
            int y2 = queries[i, 2] - 1;
            int x2 = queries[i, 3] - 1;

            for (int x = x1 + 1; x <= x2; x++)
            {
                list.Add((board[x, y1], x, y1));
            }

            for (int y = y1 + 1; y <= y2; y++)
            {
                list.Add((board[x2, y], x2, y));
            }

            for (int x = x2 - 1; x >= x1; x--)
            {
                list.Add((board[x, y2], x, y2));
            }

            for (int y = y2 - 1; y >= y1; y--)
            {
                list.Add((board[x1, y], x1, y));
            }

            int minNumber = int.MaxValue;

            for (int k = 0; k < list.Count; k++)
            {
                int x = list[k].x;
                int y = list[k].y;

                int number = k == 0 ? list[list.Count - 1].number : list[k - 1].number;
                board[x, y] = number;

                minNumber = Min(minNumber, number);
            }
            answer[i] = minNumber;
        }
        return answer;
    }
}