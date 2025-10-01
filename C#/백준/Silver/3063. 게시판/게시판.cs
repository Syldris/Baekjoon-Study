#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        
        for (int t = 0; t < testcase; t++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int x1 = line[0], x2 = line[2];
            int y1 = line[1], y2 = line[3];

            int x3 = line[4], x4 = line[6];
            int y3 = line[5], y4 = line[7];

            int result = (x2 - x1) * (y2 - y1);

            int startx = Math.Max(x1, x3);
            int endx = Math.Min(x2, x4);

            int starty = Math.Max(y1, y3);
            int endy = Math.Min(y2, y4);
            int interx = Math.Max(0, endx - startx);
            int intery = Math.Max(0, endy - starty);
            sw.WriteLine(result - (interx * intery));
        }
    }
}
