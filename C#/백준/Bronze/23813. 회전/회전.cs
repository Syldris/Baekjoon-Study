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

        int n = int.Parse(sr.ReadLine());
        string text = n.ToString();

        BigInteger result = 0;
        
        for (int i = 0; i < text.Length; i++)
        {
            int cur = n % 10;
            n /= 10;
            n += cur * (int)Math.Pow(10, text.Length-1);
            result += n;
        }

        sw.Write(result);
    }
}