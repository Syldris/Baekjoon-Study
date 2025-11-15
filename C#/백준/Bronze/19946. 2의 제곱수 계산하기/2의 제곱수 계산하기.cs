#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        BigInteger n = BigInteger.Parse(sr.ReadLine());

        BigInteger value = BigInteger.Pow(2,64);

        int k = 0;
        BigInteger x = value - n;
        while (x % 2 == 0)
        {
            x /= 2;
            k++;
        }
        sw.Write(64 - k);
    }
}