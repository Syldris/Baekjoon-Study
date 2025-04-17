    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class NewEmptyCSharpScript
    {
        static int n;
        static int[,] arr;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            arr = new int[n, n];

            for (int y = 0; y < n; y++)
            {
                string line = Console.ReadLine();
                for (int x = 0; x < n; x++)
                {
                    arr[x,y] = line[x] - '0';
                }
            }

            List<int> list = new List<int>();

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (arr[x,y] == 1)
                    {
                        list.Add(BFS(x, y));
                    }
                }
            }
            list.Sort();
            Console.WriteLine(list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static int BFS(int startx, int starty)
        {
            Queue<(int,int)> queue = new Queue<(int,int)>();
            queue.Enqueue((startx, starty));

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            arr[startx, starty] = 0;
            int count = 0;
            while (queue.Count > 0)
            {
                count++;
                (int x, int y) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];

                    if (px < 0 || py < 0 || px >= n || py >= n)
                        continue;

                    if (arr[px,py] == 1)
                    {
                        queue.Enqueue((px, py));
                        arr[px,py] = 0;
                    }
                }
            }
            return count;
        }
    }
