#nullable disable
using System;
using System.Net.Sockets;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        if (b > 30)
        {
            sw.Write("Red");
        }
        else if (a <= 50 && b <= 10)
        {
            sw.Write("White");
        }
        else
        {
            sw.Write("Yellow");
        }
    }
}
