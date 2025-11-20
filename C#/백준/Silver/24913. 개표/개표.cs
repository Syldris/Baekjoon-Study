#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        long[] arr = new long[n + 2];
        long result = 0;

        long max = -1;

        for (int i = 0; i < q; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);

            if (a == 1)
            {
                arr[c] += b;
                if (c <= n)
                {
                    result += b;
                    max = Math.Max(max, arr[c]);
                }
            }
            else
            {
                long value = (arr[n + 1] + b - 1) * n;
                if (value >= result + c && arr[n+1] + b > max)
                {
                    sw.WriteLine("YES");
                }
                else
                {
                    sw.WriteLine("NO");
                }
            }
        }
    }
}