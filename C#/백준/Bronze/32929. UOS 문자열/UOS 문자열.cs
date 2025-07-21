#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());
        if (n % 3 == 1)
        {
            sw.Write('U');
        }
        else if (n % 3 == 2)
        {
            sw.Write('O');
        }
        else
        {
            sw.Write('S');
        }
    }
}
