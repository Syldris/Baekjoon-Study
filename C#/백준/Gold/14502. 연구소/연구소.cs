using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        int[,] arr = new int[m, n];
        List<(int,int)> zerolist = new List<(int, int)>();
        for (int y = 0; y < n; y++)
        {
            string[] line = Console.ReadLine().Split();
            for (int x = 0; x < m; x++)
            {
                int num = int.Parse(line[x]);
                arr[x, y] = num;
                if(num == 0)
                    zerolist.Add((x, y));
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        bool[,] visited = new bool[m, n];
        List<(int, int)> infected = new List<(int, int)>();

        int zerocount = zerolist.Count;
        int maxValue = 0;

        for (int i = 0; i < zerocount; i++)
        {
            for (int j = i+1; j < zerocount; j++)
            {
                for(int k = j+1; k < zerocount; k++)
                {
                    (int x, int y) wall1 = zerolist[i];
                    (int x, int y) wall2 = zerolist[j];
                    (int x, int y) wall3 = zerolist[k];

                    arr[wall1.x, wall1.y] = 1;
                    arr[wall2.x, wall2.y] = 1;
                    arr[wall3.x, wall3.y] = 1;

                    ZeroCounting();

                    arr[wall1.x, wall1.y] = 0;
                    arr[wall2.x, wall2.y] = 0;
                    arr[wall3.x, wall3.y] = 0;
                }
            }
        }
      
        void ZeroCounting()
        {
            int value = 0;
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    if (arr[x, y] == 2)
                    {
                        BFS(x, y);
                        VisitedReset();
                    }
                }
            }
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    if (arr[x, y] == 0)
                        value++;
                }
            }

            foreach (var (x, y) in infected)
            {
                arr[x, y] = 0;
            }
            infected.Clear();

            maxValue = Math.Max(value, maxValue);
        }

        Console.WriteLine(maxValue);

        void BFS(int startx, int starty)
        {
            Queue<(int x, int y)> queue = new Queue<(int, int)>();
            queue.Enqueue((startx, starty));
            visited[startx, starty] = true;
            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if (px < 0 || py < 0 || px >= m || py >= n)
                        continue;

                    if (!visited[px,py])
                    {
                        visited[px,py] = true;
                        if (arr[px,py] == 0)
                        {
                            arr[px, py] = 2;
                            queue.Enqueue((px, py));
                            infected.Add((px, py));
                        }
                    }
                }
            }
        }
        void VisitedReset()
        {
            for (int y = 0; y < n; y++)
            {
                for(int x = 0; x < m; x++)
                {
                    visited[x,y] = false;
                }
            }
        }
    }
}