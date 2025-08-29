#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string input = sr.ReadLine();
        double value = double.Parse(input);
        sw.WriteLine("YES");
        int result = (int)Math.Pow(10, input.Length - 2);
        sw.WriteLine($"{value * result} {result}");
    }
}
