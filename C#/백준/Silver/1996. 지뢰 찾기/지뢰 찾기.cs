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
        List<(int x, int y, int value)> list = new List<(int x, int y, int value)>();
        int[,] board = new int[n, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                if (line[x] != '.')
                {
                    list.Add((x, y, line[x] - '0'));
                }
            }
        }

        int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int[] dy = { 1, 1, 1, 0, 0, -1, -1, -1 };
        foreach (var pos in list)
        {
            board[pos.x, pos.y] = -1;
            for (int i = 0; i < 8; i++)
            {
                int px = pos.x + dx[i];
                int py = pos.y + dy[i];
                if (px < 0 || py < 0 || px >= n || py >= n)
                {
                    continue;
                }
                if(board[px, py] != -1)
                    board[px, py] += pos.value;
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (board[x, y] == -1)
                {
                    sw.Write('*');
                }
                else if (board[x, y] >= 10)
                {
                    sw.Write('M');
                }
                else
                {
                    sw.Write(board[x, y]);
                }
            }
            sw.WriteLine();
        }
    }
}
