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

        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int a = arr[0], b = arr[1], c = arr[2];

        sw.Write(Math.Max(a + c, b));
    }
}
