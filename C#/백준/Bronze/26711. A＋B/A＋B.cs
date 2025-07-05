#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        BigInteger a = BigInteger.Parse(sr.ReadLine());
        BigInteger b = BigInteger.Parse(sr.ReadLine());
        sw.Write(a + b);
    }
}
