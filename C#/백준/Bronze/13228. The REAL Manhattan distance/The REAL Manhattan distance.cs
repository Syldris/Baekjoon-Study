#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] input = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x1 = input[0], y1 = input[1], floor1 = input[2];
            int x2 = input[3], y2 = input[4], floor2 = input[5];

            sw.WriteLine(floor1 + Math.Abs(x1 - x2) + Math.Abs(y1 - y2) + floor2);
        }
    }
}
