#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int value = 4;
        int a = 1;
        int b = 1;
        while (n > value)
        {
            if (a < b)
                a++;
            else
                b++;
            value = (a + 1) * (b + 1);
        }
        sw.Write(a * 2 + b * 2);
    }
}
