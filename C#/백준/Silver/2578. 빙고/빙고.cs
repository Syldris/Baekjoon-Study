#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        bool[,] board = new bool[5, 5]; 
        (int x, int y)[] pos = new (int, int)[26]; 
        for (int y = 0; y < 5; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < 5; x++)
            {
                pos[line[x]] = (x, y);
            }
        }

        for (int y = 0; y < 5; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < 5; x++)
            {
                (int a, int b) = pos[line[x]];
                board[a, b] = true;
                if (check())
                {
                    sw.WriteLine(y * 5 + x + 1);
                    return;
                }
            }
        }

        bool check()
        {
            int value = 0;
            for (int y = 0; y < 5; y++)
            {
                bool bingo = true;
                for (int x = 0; x < 5; x++)
                {
                    if (board[x, y] == false)
                    {
                        bingo = false;
                        break;
                    }
                }
                if (bingo)
                {
                    value++;
                }
            }
            for (int x = 0; x < 5; x++)
            {
                bool bingo = true;
                for (int y = 0; y < 5; y++)
                {
                    if (board[x, y] == false)
                    {
                        bingo = false;
                        break;
                    }
                }
                if (bingo)
                {
                    value++;
                }
            }
            for (int v = 0; v < 5; v++)
            {
                if (!board[v, v])
                {
                    break;
                }
                if (v == 4)
                {
                    value++;
                }
            }
            for (int k = 4; k >= 0; k--)
            {
                if (!board[k, 4-k])
                {
                    break;
                }
                if (k == 0)
                {
                    value++;
                }
            }
            if (value >= 3)
            {
                return true;
            }
            return false;
        }
    }
}