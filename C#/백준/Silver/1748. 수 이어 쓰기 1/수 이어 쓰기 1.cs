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

        int diff = 9;
        int result = 0;
        int weight = 1;
        while (n > diff)
        {
            result += weight * diff;
            n -= diff;
            diff = diff * 10;
            weight++;
        }
        result += n * weight;
        sw.Write(result);
    }
}
