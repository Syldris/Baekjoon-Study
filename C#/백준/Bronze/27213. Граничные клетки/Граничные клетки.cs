#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        if (a == 1 || b == 1)
        {
            sw.Write(a * b);
            return;
        }
        sw.Write((long)2 * a + 2 * b - 4);
    }
}
