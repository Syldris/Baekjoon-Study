using System;
using System.Collections;
using System.Numerics;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcase; t++)
        {
            string[] input = sr.ReadLine().Split(' ');  
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);
            char[,] board = new char[m, n];

            (int x, int y) startPos = (0, 0);
            List<(int x, int y)> firelist = new List<(int, int)>();
            int[,] fireTime = new int[m, n];
            for(int y = 0; y < n; y++)
            {
                for(int x = 0; x< m; x++)
                {
                    fireTime[x,y] = int.MaxValue;
                }
            }


            for (int y = 0; y < n; y++)
            {
                string line = sr.ReadLine();
                for (int x = 0; x < m; x++)
                {
                    board[x, y] = line[x];
                    if (line[x] == '*')
                        firelist.Add((x,y));
                    if (line[x] == '@')
                    {
                        startPos = (x, y);
                        board[x, y] = '.';
                    }
                }
            }

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            Queue<(int x, int y, int sec)> firequeue = new Queue<(int, int, int)>();
            foreach (var fire in firelist)
            {
                fireTime[fire.x, fire.y] = 0;
                firequeue.Enqueue((fire.x, fire.y, 0));
            }
            while (firequeue.Count > 0)
            {
                (int x, int y, int sec) = firequeue.Dequeue();
                sec++;

                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if (px < 0 || py < 0 || px >= m || py >= n)
                    {
                        continue;
                    }

                    if (board[px, py] == '.' && sec< fireTime[px,py])
                    {
                        fireTime[px,py] = sec;
                        firequeue.Enqueue((px, py, sec));
                    }
                }
            }

            int[,] visited = new int [m,n];
            for(int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    visited[x,y] = int.MaxValue;
                }
            }
            visited[startPos.x, startPos.y] = 0;

            Queue<(int x, int y, int sec)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((startPos.x, startPos.y, 0));
            bool escape = false;

            while (queue.Count > 0)
            {
                (int x, int y, int sec) = queue.Dequeue();

                if(escape)
                    break;

                sec++;
                for(int i = 0; i < 4;  i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if(px < 0 || py < 0 || px >= m || py >= n)
                    {
                        sw.WriteLine(sec);
                        escape = true;
                        break;
                    }

                    if (board[px, py] == '.' && sec < fireTime[px,py] && sec < visited[px,py])
                    {
                        visited[px, py] = sec;
                        queue.Enqueue((px, py, sec));
                    }
                }
            }
            if(!escape)
                sw.WriteLine("IMPOSSIBLE");
        }
    }
}