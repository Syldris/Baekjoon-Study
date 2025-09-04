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
        for (int t = 0; t < testcase; t++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int value = 0;
            int result = 0;
            for (int i = 1; i < line.Length; i++)
            {
                value += line[i];
            }
            value /= line[0];
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] > value)
                {
                    result++;
                }
            }
            float f = (float)result / line[0] * 100;
            sw.WriteLine($"{f:F3}%");
        }
    }
}
