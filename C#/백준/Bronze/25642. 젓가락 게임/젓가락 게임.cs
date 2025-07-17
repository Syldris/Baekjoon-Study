#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        while (true)
        {
            b += a;
            if (b >= 5)
            {
                sw.Write("yt");
                return;
            }
            a += b;
            if (a >= 5)
            {
                sw.Write("yj");
                return;
            }
        }
    }
}
