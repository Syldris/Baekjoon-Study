#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int k = int.Parse(input[2]);

            int result = 0;
            int value = 0;
            for (int i = 0; i < m; i++)
            {
                value += arr[i];
            }
            if (value < k)
            {
                result++;
            }

            if (n == m)
            {
                sw.WriteLine(result);
                continue;
            }

            int start = 0; int end = m;
            while (start != n - 1)
            {
                value -= arr[start++];
                value += arr[end++ % n];
                if (value < k)
                {
                    result++;
                }
            }

            sw.WriteLine(result);
        }
    }
}