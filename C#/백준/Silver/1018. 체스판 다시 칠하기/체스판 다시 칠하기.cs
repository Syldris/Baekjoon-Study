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
        string answer = "WBWBWBWBBWBWBWBWWBWBWBWBBWBWBWBWWBWBWBWBBWBWBWBWWBWBWBWBBWBWBWBW";

        string[] board = new string[n];
        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            board[y] = line;
        }

        int result = 64;
        for (int x = 0; x <= m - 8; x++)
        {
            for (int y = 0; y <= n - 8; y++)
            {
                StringBuilder sb = new StringBuilder();
                for (int len = 0; len < 8; len++)
                {
                    sb.Append(board[y + len][x..(x + 8)]);
                }

                int value = 0;
                for (int i = 0; i < 64; i++)
                {
                    if (answer[i] != sb[i])
                    {
                        value++;
                    }
                }
                value = Math.Min(value, 64-value);
                result = Math.Min(result, value);
            }
        }

        sw.WriteLine(result);
    }
}