using System;
using System.Numerics;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        (char cell, bool painted)[,] board = new (char, bool)[n, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                board[x, y].cell = line[x];
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        int result1 = 0;
        int result2 = 0;

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if(!board[x,y].painted)
                {
                    board[x, y].painted = true;
                    Painting(x, y);
                    result1++;
                }
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                board[x,y].painted = false;
                if (board[x, y].cell == 'G')
                    board[x, y].cell = 'R';
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (!board[x, y].painted)
                {
                    board[x, y].painted = true;
                    Painting(x, y);
                    result2++;
                }
            }
        }

        sw.Write($"{result1} {result2}");

        void Painting(int x, int y)
        {
            for(int i = 0; i < 4;  i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if(px < 0 || py < 0 || px >= n || py >= n)
                    continue;

                if (!board[px,py].painted && board[x,y].cell == board[px,py].cell)
                {
                    board[px, py].painted = true;
                    Painting(px, py);
                }
            }
        }
    }
}