#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 1; i < n; i++)
        {
            sw.Write(new String(' ', n - i));
            sw.WriteLine(new String('*', i));
        }
        sw.WriteLine(new String('*', n));

        for (int i = 1; i < n; i++)
        {
            sw.Write(new String(' ', i));
            sw.WriteLine(new String('*', n - i));
        }
    }
}