#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int value = 0;
        for (int i = 0; i < 5; i++)
        {
            value += int.Parse(sr.ReadLine());   
        }
        sw.Write(value);
    }
}
