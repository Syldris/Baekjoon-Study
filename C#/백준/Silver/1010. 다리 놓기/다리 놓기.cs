#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        long[,] arr = new long[31, 31];

        for (int i = 1; i <= 30; i++)
        {
            arr[i, 0] = 1;
            arr[i, i] = 1;
            for (int j = 1; j < i; j++)
            {
                arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j];
            }
        }
        for (int t = 0; t < testcase; t++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            sw.WriteLine(arr[b, a]);
        }

    }
}
