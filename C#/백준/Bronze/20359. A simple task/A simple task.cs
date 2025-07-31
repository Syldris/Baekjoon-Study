#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int p = 0;

        while (n % 2 == 0)
        {
            n /= 2;
            p++;
        }
        sw.Write($"{n} {p}");
    }
}
