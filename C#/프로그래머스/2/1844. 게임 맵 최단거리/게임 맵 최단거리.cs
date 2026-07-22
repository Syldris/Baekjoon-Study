using System;
using System.Collections.Generic;
class Solution
{
    public int solution(int[,] maps)
    {
        Queue<(int x, int y, int time)> queue = new Queue<(int x, int y, int time)>();

        int m = maps.GetLength(1);
        int n = maps.GetLength(0);

        bool[,] visited = new bool[m, n];

        queue.Enqueue((0, 0, 1));
        visited[0, 0] = true;

        int[] dx = new int[4] { -1, 1, 0, 0 };
        int[] dy = new int[4] { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();
            if (x == m - 1 && y == n - 1)
            {
                return time;
            }

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (maps[y, x] == 0)
                    continue;

                if (!visited[px, py])
                {
                    visited[px, py] = true;
                    queue.Enqueue((px, py, time + 1));
                }
            }
        }

        return -1;
    }
}