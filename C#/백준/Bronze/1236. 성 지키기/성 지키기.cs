#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        char[,] board = new char[m, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
            }
        }

        int row = 0;
        for (int y = 0; y < n; y++)
        {
            bool plus = true;
            for (int x = 0; x < m; x++)
            {
                if (board[x, y] == 'X')
                {
                    plus = false;
                    break;
                }
            }
            if (plus)
                row++;
        }

        int col = 0;
        for (int x = 0; x < m; x++)
        {
            bool plus = true;
            for (int y = 0; y < n; y++)
            {
                if (board[x, y] == 'X')
                {
                    plus = false;
                    break;
                }
            }
            if (plus)
                col++;
        }


        sw.Write(Math.Max(row, col));
    }
}