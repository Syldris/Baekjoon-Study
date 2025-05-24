using System;
using System.Collections;
using System.Numerics;
using System.Text;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int y = int.Parse(inputs[0]);
        int x = int.Parse(inputs[1]);
        int k = int.Parse(inputs[2]);

        char[,] board = new char[x * k, y * k];


        for (int i = 0; i < y; i++)
        {
            string line = sr.ReadLine();
            for (int j = 0; j < x; j++)
            {
                char c = line[j];

                for(int dy = 0; dy < k; dy++)
                {
                    for(int dx = 0; dx < k; dx++)
                    {
                        board[j * k + dx, i * k + dy] = c;
                    }
                }
            }
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < y*k; i++)
        {
            for (int j = 0; j < x*k; j++)
            {
                sb.Append(board[j,i]);
            }
            sb.AppendLine();
        }
        sw.Write(sb);

    }
}