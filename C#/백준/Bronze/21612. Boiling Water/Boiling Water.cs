#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int value = n * 5 - 400;
        sw.WriteLine(value);
        sw.WriteLine(value > 100 ? -1 : value < 100 ? 1 : 0);
    }
}
