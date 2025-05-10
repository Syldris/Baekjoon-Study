using System;

public class Program
{
    static void Main()
    {
        int[,] board = new int[9, 9];

        bool[,] row = new bool[9, 10];
        bool[,] col = new bool[9, 10];
        bool[,] square = new bool[9, 10];

        List<(int x, int y)> list = new List<(int, int)>();

        int GetSquare(int x, int y) => (x / 3) * 3 + (y / 3);

        for (int y = 0; y < 9; y++)
        {
            string line = Console.ReadLine();
            for (int x = 0; x < 9; x++)
            {
                int num = line[x] - '0';
                board[x, y] = num;
                if(num == 0)
                {
                    list.Add((x, y));
                }
                else
                {
                    row[y, num] = true;
                    col[x, num] = true;
                    square[GetSquare(x,y), num] = true;
                }
            }
        }

        int listCount = list.Count;

        bool BackTrack(int index)
        {
            if(index == list.Count)
                return true;

            (int x, int y) = list[index];

            for (int num = 1; num <= 9; num++)
            {
                if (row[y, num] || col[x, num] || square[GetSquare(x, y), num])
                    continue;

                board[x, y] = num;
                row[y, num] = true;
                col[x, num] = true;
                square[GetSquare(x, y), num] = true;
                
                if(BackTrack(index+1))
                    return true;

                board[x, y] = 0;
                row[y, num] = false;
                col[x, num] = false;
                square[GetSquare(x, y), num] = false;
            }
            return false;
        }

        BackTrack(0);

        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                Console.Write(board[x, y]);
            }
            Console.WriteLine();
        }
    }
}
