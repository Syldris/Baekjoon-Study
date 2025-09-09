#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        bool[,] board = new bool[n, n];
        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                if (line[x] == '.')
                {
                    board[x,y] = true;
                }
            }
        }

        int row = 0;
        int col = 0;

        for (int y = 0; y < n; y++)
        {
            int result = 0;
            for (int x = 0; x < n; x++)
            {
                if (board[x, y])
                {
                    result++;
                }
                else
                {
                    if (result >= 2)
                    {
                        row++;
                    }
                    result = 0;
                }
            }
            if (result >= 2)
            {
                row++;
            }
        }
        for (int x = 0; x < n; x++)
        {
            int result = 0;
            for (int y = 0; y < n; y++)
            {
                if (board[x, y])
                {
                    result++;
                }
                else
                {
                    if (result >= 2)
                    {
                        col++;
                    }
                    result = 0;
                }
            }
            if (result >= 2)
            {
                col++;
            }
        }
        sw.WriteLine($"{row} {col}");
    }
}
