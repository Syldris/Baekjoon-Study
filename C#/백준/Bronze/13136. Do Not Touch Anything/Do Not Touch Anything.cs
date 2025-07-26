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

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int xvalue = 0;
        int yvalue = 0;
        xvalue += n / k;
        if (n % k != 0)
        {
            xvalue++;
        }
        yvalue += m / k;
        if (m % k != 0)
        {
            yvalue++;
        }
        sw.WriteLine((long)xvalue * yvalue);
    }
}
