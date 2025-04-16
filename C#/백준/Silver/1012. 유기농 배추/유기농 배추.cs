using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string[] input = Console.ReadLine().Split();
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);
            int k = int.Parse(input[2]);

            int[,] arr = new int[m, n];
            for(int j = 0; j < k; j++)
            {
                string[] line = Console.ReadLine().Split();
                int x = int.Parse(line[0]);
                int y = int.Parse(line[1]);
                arr[x, y] = 1;
            }

            int count = 0;

            for(int y = 0; y< n; y++)
            {
                for(int x = 0; x < m; x++)
                {
                    if (arr[x,y] == 1)
                    {
                        BFS(x, y, n, m, arr);
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }

    static void BFS(int posx, int posy, int n, int m, int[,] arr)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int x, int y)> queue = new Queue<(int, int)>();

        arr[posx, posy] = 0;
        queue.Enqueue((posx, posy));

        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            for (int j = 0; j < 4; j++)
            {
                int px = x + dx[j];
                int py = y + dy[j];
                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (arr[px,py] == 1)
                {
                    queue.Enqueue((px, py));
                    arr[px,py] = 0;
                }
            }
        }
    }
}
