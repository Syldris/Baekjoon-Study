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

        int k = int.Parse(sr.ReadLine());

        int result = n*10;
        if (n >= 3)
        {
            result += 20;
        }
        if (n >= 5)
        {
            result += 50;
        }

        if (k > 1000)
        {
            result -= 15;
        }
        sw.WriteLine(Math.Max(0,result));
    }
}