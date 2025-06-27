#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        sw.Write((a + b) % 12 == 0 ? 12 : (a + b) % 12);
    }
}
