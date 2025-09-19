#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        for (int t = 0; t < 3; t++)
        {
            int n = int.Parse(sr.ReadLine());
            BigInteger value = 0;
            for (int i = 0; i < n; i++)
            {
                value += BigInteger.Parse(sr.ReadLine());
            }
            sw.WriteLine(value > 0 ? '+' : value < 0 ? '-' : '0');
        }
    }
}
