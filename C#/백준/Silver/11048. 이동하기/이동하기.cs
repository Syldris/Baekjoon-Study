#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] board = new int[m, n];

        for (int y = 0; y < n; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < m; x++)
            {
                int v1 = line[x];
                int v2 = line[x];

                if (x != 0)
                {
                    v1 += board[x - 1, y];
                }
                if (y != 0)
                {
                    v2 += board[x, y - 1];
                }
                board[x, y] = Math.Max(v1,v2);
            }
        }
        sw.Write(board[m-1,n-1]);

    }
}
