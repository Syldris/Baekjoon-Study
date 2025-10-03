#nullable disable
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        a--;
        b--;

        List<(int x, int y)> list = new List<(int, int)>();
        char[,] board = new char[10, 10];
        for (int y = 0; y < 10; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < 10; x++)
            {
                if (line[x] == 'o')
                {
                    list.Add((x, y));
                }
                board[x, y] = line[x];
            }
        }

        foreach (var item in list)
        {
            for (int x = 0; x < 10; x++)
            {
                if (board[x, item.y] == 'x')
                    board[x, item.y] = 'o';
            }
            for (int y = 0; y < 10; y++)
            {
                if (board[item.x, y] == 'x')
                    board[item.x, y] = 'o';
            }
        }

        int result = 100;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (board[x, y] == 'x')
                {
                    result = Math.Min(result, Math.Abs(x - b) + Math.Abs(y - a));
                }
            }
        }
        sw.Write(result);

    }
}