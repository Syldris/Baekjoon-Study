#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        sw.Write(result);
    }
}
