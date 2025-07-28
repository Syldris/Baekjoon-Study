#nullable disable
using System;
using System.Text;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        BigInteger n = BigInteger.Parse(sr.ReadLine());

        if (n >= -32768 && n <= 32767)
        {
            sw.Write("short");
        }
        else if (n >= -2147483648 && n <= 2147483647)
        {
            sw.Write("int");
        }
        else
        {
            sw.Write("long long");
        }

    }
}
