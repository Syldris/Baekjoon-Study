#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int preva = -1;
        int prevb = -1;

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (preva > a || prevb > b)
            {
                sw.Write("no");
                return;
            }
            preva = a;
            prevb = b;
        }
        sw.Write("yes");
    }
}
