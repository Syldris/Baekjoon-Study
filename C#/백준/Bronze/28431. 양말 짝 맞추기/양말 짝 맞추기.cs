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

        int result = 0;
        for (int i = 0; i < 5; i++)
        {
            result ^= int.Parse(sr.ReadLine());
        }
        sw.Write(result);
    }
}
