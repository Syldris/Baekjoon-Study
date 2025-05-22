using System;
using System.Numerics;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int result = 6;
        for (int i = 11; i <= a; i++)
        {
            result *= i;
        }
        sw.Write(result);
    }
}