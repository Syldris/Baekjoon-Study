#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int a = int.Parse(input[1]);
        int b = int.Parse(input[2]);
        int c = int.Parse(input[3]);
        int d = int.Parse(input[4]);

        int aValue = int.MaxValue;
        int cValue = int.MaxValue;
        if (n % a == 0)
        {
            aValue = (n / a) * b;
        }
        else
        {
            aValue = (n / a + 1) * b;
        }

        if (n % c == 0)
        {
            cValue = (n / c) * d;
        }
        else
        {
            cValue = (n / c + 1) * d;
        }
        sw.Write(Math.Min(aValue, cValue));
    }
}
