using System;
public class Solution
{
    enum State
    {
        Down,
        Right,
        Up
    }

    public int[] solution(int n)
    {
        int[][] arr = new int[n][];

        for (int i = 0; i < n; i++)
            arr[i] = new int[i + 1];

        int x = 0, y = -1;
        int value = 0;
        State state = State.Down;

        for (int i = 0; i < n; i++)
        {
            if (state == State.Down)
            {
                for (int j = 0; j < n - i; j++)
                {
                    y++;
                    arr[y][x] = ++value;
                }
                state = State.Right;
            }
            else if (state == State.Right)
            {
                for (int j = 0; j < n - i; j++)
                {
                    x++;
                    arr[y][x] = ++value;
                }
                state = State.Up;
            }
            else
            {
                for (int j = 0; j < n - i; j++)
                {
                    x--;
                    y--;
                    arr[y][x] = ++value;
                }
                state = State.Down;
            }
        }

        int[] answer = new int[value];
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                answer[index++] = arr[i][j];
            }
        }

        return answer;
    }
}