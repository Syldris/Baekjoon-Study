#nullable disable
using System;
using System.Numerics;
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

        List<(int x, int y)> list = new List<(int x, int y)>();

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (board[x, y] == '.')
                {
                    if (x + 2 < m && board[x + 1, y] == '.' && board[x + 2, y] == '.' && (x == 0 || board[x - 1, y] == '#'))
                    {
                        list.Add((x, y));
                    }
                    else if(y + 2 < n && board[x, y + 1] == '.' && board[x, y + 2] == '.' && (y == 0 || board[x, y - 1] == '#'))
                    {
                        list.Add((x, y));
                    }
                }
            }
        }
        sw.WriteLine(list.Count);
        foreach (var item in list)
        {
            sw.WriteLine($"{item.y + 1} {item.x + 1}");
        }
    }
}
