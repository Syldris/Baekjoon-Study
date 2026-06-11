using System;
using System.Collections.Generic;
public class Solution
{
    int n, m;
    public int[] solution(string[] maps)
    {

        n = maps.Length;
        m = maps[0].Length;

        bool[,] visited = new bool[n, m];

        List<int> list = new List<int>();

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (!visited[y, x] && maps[y][x] != 'X')
                {
                    int land = BFS(y, x, visited, maps);
                    list.Add(land);
                }
            }
        }

        list.Sort();
        if (list.Count == 0)
            return new int[1] { -1 };
        else
            return list.ToArray();
    }

    int[] dx = new int[4] { -1, 1, 0, 0 };
    int[] dy = new int[4] { 0, 0, -1, 1 };

    int BFS(int startY, int startX, bool[,] visited, string[] maps)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();

        int value = maps[startY][startX] - '0';

        visited[startY, startX] = true;
        queue.Enqueue((startY, startX));

        while (queue.Count > 0)
        {
            (int y, int x) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (!visited[py, px] && maps[py][px] != 'X')
                {
                    value += maps[py][px] - '0';
                    visited[py, px] = true;
                    queue.Enqueue((py, px));
                }
            }

        }

        return value;
    }
}