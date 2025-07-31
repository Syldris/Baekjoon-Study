#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        char[,] board = new char[n, n];
        int[,,] visited = new int[n, n, 4];

        bool poschange = false;
        (int x, int y) startPos = (0, 0);
        (int x, int y) endPos = (0, 0);


        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                board[x, y] = line[x];
                for (int i = 0; i < 4; i++)
                {
                    visited[x, y, i] = int.MaxValue;
                }
                if (line[x] == '#')
                {
                    if (poschange)
                    {
                        endPos = (x, y);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            visited[x, y, i] = 0;
                        }
                        startPos = (x, y);
                        poschange = true;
                    }
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 }; ;
        PriorityQueue<(int x, int y, int dir, int value), int> queue = new();
        for (int i = 0; i < 4; i++)
        {
            queue.Enqueue((startPos.x, startPos.y, i, 0), 0);
        }

        while (queue.Count > 0)
        {
            (int x, int y, int dir, int value) = queue.Dequeue();
            if (x == endPos.x && y == endPos.y)
            {
                sw.Write(value);
                return;
            }

            if (value > visited[x, y, dir])
                continue;

            int px = x + dx[dir];
            int py = y + dy[dir];
            if (px < 0 || py < 0 || px >= n || py >= n)
                continue;

            if (board[px, py] == '*')
                continue;

            if (board[px, py] == '.' || board[px, py] == '#')
            {
                if (value < visited[px, py, dir])
                {
                    visited[px, py, dir] = value;
                    queue.Enqueue((px, py, dir, value), value);
                }
            }
            else if (board[px, py] == '!')
            {
                for (int i = 0; i < 4; i++)
                {
                    int curvalue = dir == i ? value : value + 1;
                    if (curvalue < visited[px, py, i])
                    {
                        visited[px, py, i] = curvalue;
                        queue.Enqueue((px, py, i, curvalue), curvalue);
                    }
                }
            }
        }
    }
}
