#nullable disable
using System;
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
        int k = int.Parse(input[2]);
        int[,] arr = new int[n, m];
        
        for (int y = 0; y < n; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < m; x++)
            {
                arr[y,x] = line[x];
            }
        }

        int[] row = new int[n];

        for (int i = 0; i < n; i++)
        {
            row[i] = i;
        }
        for (int q = 0; q < k; q++)
        {
            int[] query = sr.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 0)
            {
                int a = query[1];
                int b = query[2];
                int c = query[3];
                arr[row[a], b] = c;
            }
            else if (query[0] == 1)
            {
                int a = query[1];
                int b = query[2];
                (row[a], row[b]) = (row[b], row[a]);
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                sw.Write($"{arr[row[y], x]} ");
            }
            sw.WriteLine();
        }
    }
}
