using System;
using System.Numerics;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int t = int.Parse(sr.ReadLine());
        for (int tastcase = 0; tastcase < t; tastcase++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            sw.WriteLine($"{a} {b}");
            sw.WriteLine(a * b - (2 * (a - 1)));
        }
    }
}