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
        string line = sr.ReadLine();
        long total = 0;
        long value = 0;

        int num = 0;
        int index = 0;
        foreach (var c in line)
        {
            if (c == ' ')
            {
                value += num;
                total += index;
                index++;
                num = 0;
            }
            else
            {
                num = num * 10 + (c - '0');
            }
        }
        value += num;
        total += index;
        sw.Write(value - total);
    }
}
