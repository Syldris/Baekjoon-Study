#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        
        for (int t = 0; t < testcase; t++)
        {
            string space = sr.ReadLine();
            string[] input = sr.ReadLine().Split();
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

            char[] row = new char[] { '>', 'o', '<' };
            char[] col = new char[] { 'v', 'o', '^' };
            int result = 0;

            for (int y = 0; y < n; y++)
            {
                for (int x = 2; x < m; x++)
                {
                    if (board[x - 2, y] == row[0] && board[x - 1, y] == row[1] && board[x, y] == row[2])
                    {
                        result++;
                    }
                }
            }

            for (int x = 0; x < m; x++)
            {
                for (int y = 2; y < n; y++)
                {
                    if (board[x, y - 2] == col[0] && board[x, y - 1] == col[1] && board[x, y] == col[2])
                    {
                        result++;
                    }
                }
            }

            sw.WriteLine(result);
        }

    }
}