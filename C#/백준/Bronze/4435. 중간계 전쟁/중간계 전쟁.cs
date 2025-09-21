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
        int[] value1 = new int[6] { 1, 2, 3, 3, 4, 10 };
        int[] value2 = new int[7] { 1, 2, 2, 2, 3, 5, 10 };
        for (int t = 1; t <= testcase; t++)
        {
            int[] one = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] two = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int result1 = 0;
            int result2 = 0;
            for (int i = 0; i < 6; i++)
            {
                result1 += value1[i] * one[i];
                result2 += value2[i] * two[i];
            }
            result2 += value2[6] * two[6];
            if (result1 > result2)
            {
                sw.WriteLine($"Battle {t}: Good triumphs over Evil");
            }
            else if (result1 < result2)
            {
                sw.WriteLine($"Battle {t}: Evil eradicates all trace of Good");
            }
            else
            {
                sw.WriteLine($"Battle {t}: No victor on this battle field");
            }
        }
    }
}
