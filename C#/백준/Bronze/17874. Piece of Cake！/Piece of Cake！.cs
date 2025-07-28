#nullable disable
using System;
using System.Text;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);
        int value1 = Math.Max(a - b, b);
        int value2 = Math.Max(a - c, c);
        sw.WriteLine(value1 * value2 * 4);
    }
}
