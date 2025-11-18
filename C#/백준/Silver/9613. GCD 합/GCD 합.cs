#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int[] input = sr.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            int n = input[0];
            long result = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = i+1; j <= n; j++)
                {
                    int a = input[i];
                    int b = input[j];

                    while (b != 0)
                    {
                        (a, b) = (b, a % b); 
                    }
                    result += a;
                }
            }
            sw.WriteLine(result);
        }
    }
}