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

        int len = 1;

        while (n >= pow(2, len))
        {
            len++;
        }

        BigInteger result = 0;
        for (int i = 0; i < len; i++)
        {
            int bit = (int)((n >> i) & 1);
            if (bit == 1)
            {
                result += pow(3, i);
            }
        }

        sw.Write(result);

        BigInteger pow(BigInteger value, int n)
        {
            BigInteger result = 1;
            while (n-- != 0)
            {
                result *= value;
            }
            return result;
        }
    }
}