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
        int q1 = 0, q2 = 0, q3 = 0, q4 = 0;
        int axis = 0;
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            if (x == 0 || y == 0)
            {
                axis++;
                continue;
            }
            if (x > 0 && y > 0)
            {
                q1++;
            }
            else if (x < 0 && y > 0)
            {
                q2++;
            }
            else if (x < 0 && y < 0)
            {
                q3++;
            }
            else
            {
                q4++;
            }
        }
        sw.WriteLine($"Q1: {q1}");
        sw.WriteLine($"Q2: {q2}");
        sw.WriteLine($"Q3: {q3}");
        sw.WriteLine($"Q4: {q4}");
        sw.WriteLine($"AXIS: {axis}");
    }
}