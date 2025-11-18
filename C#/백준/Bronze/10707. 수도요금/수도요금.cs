#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        int c = int.Parse(sr.ReadLine());
        int d = int.Parse(sr.ReadLine());
        int n = int.Parse(sr.ReadLine());

        int x = a * n;
        int y = n <= c ? b : b + (n - c) * d;
        sw.Write(Math.Min(x, y));
    }
}