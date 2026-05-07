using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(string[] maps)
    {
        int xlen = maps[0].Length; // 가로 길이
        int ylen = maps.Length; // 세로 길이

        int[,,] visited = new int[xlen, ylen, 2];
        char[,] board = new char[xlen, ylen];

        (int x, int y) startPos = (0, 0);

        for (int y = 0; y < ylen; y++)
        {
            for (int x = 0; x < xlen; x++)
            {
                board[x, y] = maps[y][x];

                if (board[x, y] == 'S')
                    startPos = (x, y);

                for (int k = 0; k < 2; k++)
                {
                    visited[x, y, k] = 100000;
                }
            }
        }

        int[] dx = new int[4] { -1, 1, 0, 0 };
        int[] dy = new int[4] { 0, 0, -1, 1 };

        visited[startPos.x, startPos.y, 0] = 0;
        Queue<(int x, int y, bool lever)> queue = new Queue<(int x, int y, bool lever)>();
        queue.Enqueue((startPos.x, startPos.y, false));

        while (queue.Count > 0)
        {
            (int x, int y, bool lever) = queue.Dequeue();

            if (board[x, y] == 'E' && lever) // 레버를 당긴상태로 도착점 도달
            {
                return visited[x, y, 1];
            }

            int index = lever ? 1 : 0;

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= xlen || py >= ylen)
                    continue;

                if (board[px, py] == 'X')
                    continue;

                if (board[px, py] == 'L' && index == 0) // 레버 안당긴 상태에서 당길때.
                {
                    if (visited[x, y, 0] + 1 < visited[px, py, 1]) // 당기면 1보드로 이동.
                    {
                        visited[px, py, 1] = visited[x, y, 0] + 1;
                        queue.Enqueue((px, py, true));
                    }
                }
                else if (visited[x, y, index] + 1 < visited[px, py, index]) // 이동
                {
                    visited[px, py, index] = visited[x, y, index] + 1;
                    queue.Enqueue((px, py, lever));
                }
            }
        }

        return -1;
    }
}