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
        int m = int.Parse(sr.ReadLine());
        if (n == 2 && m == 18)
        {
            sw.Write("Special");
        }
        else if ((n == 2 && m < 18) || n == 1)
        {
            sw.Write("Before");
        }
        else
        {
            sw.Write("After");
        }
    }
}
