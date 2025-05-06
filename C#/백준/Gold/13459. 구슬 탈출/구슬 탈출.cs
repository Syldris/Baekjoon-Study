using System;
using System.Text;
using System.IO;
public class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        char[,] arr = new char[m, n];

        (int x, int y) redPos = (0, 0);
        (int x, int y) bluePos = (0, 0);
        (int x, int y) holePos = (0, 0);

        for (int y = 0; y < n; y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < m; x++)
            {
                char c = line[x];
                if (c == 'R')
                    redPos = (x, y);
                else if (c == 'B')
                    bluePos = (x, y);
                else if(c == 'O')
                    holePos = (x, y);

                arr[x, y] = c;
            }
        }

        bool[,,,] visited = new bool[m, n, m, n]; //redX, redY, blueX, blueY
        visited[redPos.x,redPos.y,bluePos.x,bluePos.y] = true;


        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        
        (int,int,int) Move(int x, int y, int dx, int dy)
        {
            int count = 0;
            while (arr[x+dx,y+dy] != '#')
            {
                x += dx;
                y += dy;    
                count++;
                if((x, y) == holePos)
                    break;
            }
            return (x, y, count);
        }

        
        Queue<(int rx, int ry, int bx, int by, int count)> queue = new Queue<(int, int, int, int, int)>();
        queue.Enqueue((redPos.x, redPos.y, bluePos.x, bluePos.y, 1));


        while (queue.Count > 0)
        {
            (int rx, int ry, int bx, int by, int count) = queue.Dequeue();
            if(count > 10)
                continue;

            for (int dir = 0; dir < 4; dir++)
            {
                (int curRedx, int curRedy, int curRedCount) = Move(rx, ry, dx[dir], dy[dir]);
                (int curBluex, int curBluey, int curBlueCount) = Move(bx, by, dx[dir], dy[dir]);
                
                if((curBluex, curBluey) == holePos)
                    continue;
                if((curRedx, curRedy) == holePos)
                {
                    Console.WriteLine(1);
                    return;
                }

                if((curRedx,curRedy) == (curBluex,curBluey))
                {
                    if(curRedCount > curBlueCount)
                    {
                        curRedx -= dx[dir];
                        curRedy -= dy[dir];
                    }
                    else
                    {
                        curBluex -= dx[dir];
                        curBluey -= dy[dir];
                    }
                }

                if (!visited[curRedx,curRedy,curBluex,curBluey])
                {
                    visited[curRedx, curRedy, curBluex, curBluey] = true;
                    queue.Enqueue((curRedx, curRedy, curBluex, curBluey, count + 1));
                }
            }
        }

        Console.WriteLine(0);
    }
}
