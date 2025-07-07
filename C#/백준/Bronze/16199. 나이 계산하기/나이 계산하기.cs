#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] inputa = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] inputb = sr.ReadLine().Split().Select(int.Parse).ToArray();

        (int year, int month, int day) a = (inputa[0], inputa[1], inputa[2]);
        (int year, int month, int day) b = (inputb[0], inputb[1], inputb[2]);


        int age1 = b.year - a.year - 1;
        if (a.month < b.month || (a.month == b.month && a.day <= b.day))
        {
            age1++;
        }
            
        int age2 = b.year - a.year + 1;
        int age3 = b.year - a.year;
        sw.WriteLine(Math.Max(age1, 0));
        sw.WriteLine(age2);
        sw.WriteLine(age3);
    }
}
