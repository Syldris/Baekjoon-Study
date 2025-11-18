#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int scoreA = 0;
        int scoreB = 0;

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (a > b)
            {
                scoreA += a + b;
            }
            else if (a < b)
            {
                scoreB += a + b;
            }
            else
            {
                scoreA += a;
                scoreB += b;
            }
        }
        sw.WriteLine($"{scoreA} {scoreB}");
    }
}