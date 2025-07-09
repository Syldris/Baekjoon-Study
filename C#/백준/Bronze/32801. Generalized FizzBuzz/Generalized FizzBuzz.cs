#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int a = 0, b = 0, c = 0;

        for (int i = 1; i <= input[0]; i++)
        {
            if (i % input[1] == 0 && i % input[2] == 0)
            {
                c++;
            }
            else if (i % input[1] == 0)
            {
                a++;
            }
            else if (i % input[2] == 0)
            {
                b++;
            }
        }

        sw.Write($"{a} {b} {c}");
    }
}
