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
        int[,] result = new int[m, n];
        int[,] tag = new int[m, n];
        bool[,] visited = new bool[m, n];

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        StringBuilder sb = new StringBuilder();

        for (int y = 0; y < n; y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < m; x++)
            {
                int number = line[x] - '0';
                arr[x, y] = number;
                if(number == 0)
                    result[x, y] = 0;
                else
                    result[x, y] = -1;
            }
        }

        int tagNumber = 1;

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (result[x, y] == 0)
                {
                    ResultBFS(x, y, tagNumber);
                    tagNumber++;
                }
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (arr[x,y] == 1)
                {
                    arr[x,y] = BFS(x,y);
                }
                sb.Append(arr[x,y]);
            }
            sb.AppendLine();
        }

        void ResultBFS(int startx, int starty, int tagnum)
        {
            List<(int x, int y)> list = new List<(int, int)>();
            visited[startx, starty] = true;

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((startx, starty));

            int count = 0;
            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();
                list.Add((x, y));
                count++;
                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if (px < 0 || py < 0 || px >= m || py >= n || visited[px, py])
                        continue;
                    if (result[px, py] == 0)
                    {
                        queue.Enqueue((px, py));
                    }
                    visited[px, py] = true;
                }
            }
            foreach (var item in list)
            {
                result[item.x, item.y] = count;
                tag[item.x, item.y] = tagnum;
            }
        }

        int BFS(int startx, int starty)
        {
            int count = 0;
            List<int> taglist = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int px = startx + dx[i];
                int py = starty + dy[i];
                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;
                if (result[px, py] != -1)
                {
                    int tagNumber = tag[px, py];
                    if (taglist.Contains(tagNumber))
                        continue;

                    count += result[px, py];
                    taglist.Add(tag[px, py]);
                }
            }
            return (count+1) % 10;
        }

        Console.WriteLine(sb);
    }
}