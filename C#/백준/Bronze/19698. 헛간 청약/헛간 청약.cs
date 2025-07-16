#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int n = int.Parse(line[0]);
        int w = int.Parse(line[1]);
        int h = int.Parse(line[2]);
        int l = int.Parse(line[3]);

        int value = (w / l) * (h / l);
        sw.Write(Math.Min(n, value));
    }
}
