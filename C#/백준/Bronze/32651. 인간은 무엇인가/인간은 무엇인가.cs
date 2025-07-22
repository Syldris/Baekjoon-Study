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
        if (n >= 2024 && n <= 100000 && n % 2024 == 0)
        {
            sw.Write("Yes");
        }
        else
        {
            sw.Write("No");
        }
    }
}
