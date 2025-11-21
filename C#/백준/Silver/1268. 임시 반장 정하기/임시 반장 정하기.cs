#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[,] board = new int[5, n];
        for (int y = 0; y < n; y++)
        {
            string[] line = sr.ReadLine().Split();
            for (int x = 0; x < 5; x++)
            {
                board[x,y] = int.Parse(line[x]);
            }
        }

        int[] value = new int[n];
        bool[,] visited = new bool[n, n];
        for (int year = 0; year < 5; year++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        continue;
                    if (board[year, i] == board[year, j] && !visited[i,j])
                    {
                        value[i]++;
                        visited[i,j] = true;
                    }
                }
            }
        }

        int index = 1;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            if (value[i] > max)
            {
                max = value[i];
                index = i + 1;
            }
        }
        sw.Write(index);
    }
}