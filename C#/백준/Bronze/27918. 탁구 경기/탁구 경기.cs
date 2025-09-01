#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int d = 0;
        int p = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            if (line == "D") d++;
            if (line == "P") p++;

            if (Math.Abs(d - p) >= 2)
            {
                break;
            }
        }
        sw.WriteLine($"{d}:{p}");
    }
}
