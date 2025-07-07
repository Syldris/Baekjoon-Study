#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        BigInteger n = BigInteger.Parse(input[0]);
        BigInteger m = BigInteger.Parse(input[1]);
        sw.WriteLine(n / m);
        sw.WriteLine(n % m);
    }
}
