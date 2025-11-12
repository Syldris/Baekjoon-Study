#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());

        int result = 0;
        for (int t = 0; t < testcase; t++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);
            int d = int.Parse(line[3]);

            if (a >= 1000 || b >= 1600 || c >= 1500 || (d != -1 && d <= 30))
            {
                result++;
            }
        }
        sw.Write(result);
    }
}