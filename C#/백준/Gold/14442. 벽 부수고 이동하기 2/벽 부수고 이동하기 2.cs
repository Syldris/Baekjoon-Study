using System;
using System.Collections;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int k = int.Parse(inputs[2]);
        int[,] arr = new int[m, n];
        bool[,,] visited = new bool[m, n, k + 1];

        for (int y = 0; y < n; y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < m; x++)
            {
                arr[x, y] = line[x] - '0';
            }
        }

        Queue<(int posX, int posY, int time, int breakNum)> queue = new Queue<(int, int, int, int)>();

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        queue.Enqueue((0, 0, 1, 0));
        visited[0, 0, 0] = true;

        while (queue.Count > 0)
        {
            (int x, int y, int time, int breakNum) = queue.Dequeue();

            if (x == m - 1 && y == n - 1)
            {
                Console.WriteLine(time);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px >= 0 && py >= 0 && px < m && py < n)
                {
                    if (arr[px, py] == 1 && breakNum < k && !visited[px, py, breakNum + 1])
                    {
                        visited[px, py, breakNum + 1] = true;
                        queue.Enqueue((px, py, time + 1, breakNum + 1));
                    }
                    else if (arr[px, py] == 0 && !visited[px, py, breakNum])
                    {
                        visited[px, py, breakNum] = true;
                        queue.Enqueue((px, py, time + 1, breakNum));
                    }
                }
            }
        }
    Console.WriteLine(-1);
    }
}
