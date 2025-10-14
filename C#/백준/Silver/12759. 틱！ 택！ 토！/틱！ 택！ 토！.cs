#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[,] board = new int[3, 3];
        
        int player = int.Parse(sr.ReadLine());

        for (int i = 0; i < 9; i++)
        {
            string[] input = sr.ReadLine().Split();
            int y = int.Parse(input[0]);
            int x = int.Parse(input[1]);
            board[x-1, y-1] = player;

            if (check())
            {
                sw.Write(player);
                return;
            }
            player = player == 1 ? 2 : 1;
        }
        sw.Write(0);
        bool check()
        {
            for (int y = 0; y < 3; y++)
            {
                bool bingo = true;
                int value = board[0, y];
                if (value == 0)
                {
                    continue;
                }
                for (int x = 1; x < 3; x++)
                {
                    if (board[x, y] != value || board[x,y] == 0)
                    {
                        bingo = false;
                    }
                }
                if (bingo)
                    return true;
            }

            for (int x = 0; x < 3; x++)
            {
                bool bingo = true;
                int value = board[x, 0];
                if (value == 0)
                {
                    continue;
                }
                for (int y = 1; y < 3; y++)
                {
                    if (board[x, y] != value || board[x, y] == 0)
                    {
                        bingo = false;
                    }
                }
                if (bingo)
                    return true;
            }

            int v1 = board[0,0];
            if (v1 != 0 && board[1, 1] == v1 && board[2, 2] == v1)
            {
                return true;
            }

            int v2 = board[2,0];
            if (v2 != 0 && board[1, 1] == v2 && board[0, 2] == v2)
            {
                return true;
            }
            return false;
        }
    }
}