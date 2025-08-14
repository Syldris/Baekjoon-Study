#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int a = 0;
        int b = 0;
        for (int i = 0; i < n; i++)
        {
            a += 10 * (arr[i] / 30 + 1);
            b += 15 * (arr[i] / 60 + 1);
        }

        if (a < b)
        {
            sw.Write($"Y {a}");
        }
        else if (b < a)
        {
            sw.Write($"M {b}");
        }
        else
        {
            sw.Write($"Y M {a}");
        }
    }
}
