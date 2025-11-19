#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);

            if (a == 0 && b == 0 && c == 0)
            {
                break;
            }

            if (c - b == b - a && c - b != 0)
            {
                sw.WriteLine($"AP {2 * c - b}");
            }
            else
            {
                sw.WriteLine($"GP {c * (c / b)}");
            }
        }
    }
}