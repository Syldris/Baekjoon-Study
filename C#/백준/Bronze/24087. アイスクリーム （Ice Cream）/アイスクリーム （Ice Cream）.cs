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

        int s = int.Parse(sr.ReadLine());
        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        int value = a;
        int money = 250;
        while (value < s)
        {
            value += b;
            money += 100;
        }
        sw.Write(money);
    }
}
