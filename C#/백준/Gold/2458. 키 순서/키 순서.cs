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

        bool[,] link = new bool[n + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            link[a, b] = true;
        }
        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (link[i, k] && link[k, j])
                    {
                        link[i, j] = true;
                    }
                }
            }
        }

        int result = 0;

        for (int i = 1; i <= n; i++)
        {
            int high = 0;
            int row = 0;
            for (int j = 1; j <= n; j++)
            {
                if (link[i, j])
                    high++;
                if (link[j,i])
                    row++;
            }
            if (high + row == n - 1)
            {
                result++;
            }
        }

        sw.Write(result);
    }
}
