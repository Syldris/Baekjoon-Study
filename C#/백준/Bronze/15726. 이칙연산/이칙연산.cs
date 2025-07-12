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

        double [] arr = sr.ReadLine().Split(' ').Select(double.Parse).ToArray();

        double value = int.MinValue;
        value = Math.Max(arr[0] / arr[1] * arr[2], arr[0] * arr[1] / arr[2]);
        sw.Write((int)value);
    }
}
