#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());
        int f = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i <= 100; i++)
        {
            n /= 100;
            n *= 100;
            n += i;
            if (n % f == 0)
            {
                result = i;
                break;
            }
        }
        sw.Write($"{result:D2}");
    }
}