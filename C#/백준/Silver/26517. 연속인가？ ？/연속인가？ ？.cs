#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int k = int.Parse(sr.ReadLine());
        int[] ints = sr.ReadLine().Split().Select(int.Parse).ToArray();
        long ax = (long)ints[0] * k + ints[1];
        long cx = (long)ints[2] * k + ints[3];
        sw.Write(ax == cx ? $"Yes {ax}" : "No");

    }
}
