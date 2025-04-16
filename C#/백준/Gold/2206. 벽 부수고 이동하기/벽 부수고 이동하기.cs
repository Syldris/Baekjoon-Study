using System;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[,] arr = new int[m, n];

        for (int y = 0; y < n; y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < m; x++)
            {
                arr[x, y] = line[x] - '0';
            }
        }

        Queue<(int x, int y, int day, bool isBreak)> queue = new Queue<(int, int, int, bool)>();
        queue.Enqueue((0, 0, 1, false));
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        bool[,,] visited = new bool[m, n, 2];

        while (queue.Count > 0)
        {
            var (x, y, day, isBreak) = queue.Dequeue();

            if(x == m-1 && y == n-1)
            {
                Console.WriteLine(day);
                return;
            }

            for (int i = 0; i < 4;  i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                int breakIndex = isBreak ? 1 : 0;

                if (arr[px, py] == 0 && !visited[px,py,breakIndex])
                {
                    visited[px, py, breakIndex] = true;
                    queue.Enqueue((px, py, day + 1, isBreak));
                }
                else if (arr[px, py] == 1 && !visited[px, py, breakIndex])
                {
                    if (!isBreak)
                    {
                        visited[px, py, 1] = true;
                        queue.Enqueue((px, py, day + 1, true));
                    }
                }
            }
        }

        Console.WriteLine("-1");
    }
}
