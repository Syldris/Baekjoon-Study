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

        long n = long.Parse(sr.ReadLine());

        long diff = 9;
        long result = 0;
        int weight = 1;
        while (n > diff)
        {
            result = (result + weight * diff) % 1234567;
            n -= diff;
            diff = diff * 10;
            weight++;
        }
        result = (result + n * weight) % 1234567;
        sw.Write(result);
    }
}
