#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        double n = double.Parse(sr.ReadLine());
        double galon = 3.785411784;
        double mile = 1609.344;
        sw.WriteLine(100 * galon / (mile * n / 1000));
    }
}
