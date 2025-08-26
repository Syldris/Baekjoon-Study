#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 1; t <= testcase; t++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            sw.WriteLine($"Case #{t}: {line.Max()}");
        }
    }
}
