#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input1 = sr.ReadLine().Split();
        string[] input2 = sr.ReadLine().Split();
        int a = int.Parse(input1[0]);
        int b = int.Parse(input1[1]);
        int c = int.Parse(input2[0]);
        int d = int.Parse(input2[1]);

        double max = (double)a / c + (double)b / d;
        int result = 0;
        for (int i = 1; i < 4; i++)
        {
            (a, b, c, d) = (c, a, d, b);
            double value = (double)a / c + (double)b / d;
            if (value > max)
            {
                max = value;
                result = i;
            }
        }
        sw.Write(result);
    }
}