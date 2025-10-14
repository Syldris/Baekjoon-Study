#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int total = int.Parse(input[0]);
        int cur = int.Parse(input[1]);

        double value = (double)cur / total;
        double time = (double)1 / 1440;
        int result = (int)(value / time);
        sw.Write($"{result / 60:D2}:{result % 60:D2}");
    }
}