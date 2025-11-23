#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int x = int.Parse(input[0]);
        int y = int.Parse(input[1]);
        int w = int.Parse(input[2]);
        int h = int.Parse(input[3]);

        int minx = Math.Min(w - x, x);
        int miny = Math.Min(h - y, y);

        int result = Math.Min(minx, miny);
        sw.Write(result);
    }
}