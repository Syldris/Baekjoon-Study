#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split('.');
        int result = 10;
        for (int i = 1; i < input[1].Length; i++)
        {
            result *= 10;
        }
        sw.WriteLine("YES");
        sw.WriteLine($"{int.Parse(input[1])} {result}");
    }
}
