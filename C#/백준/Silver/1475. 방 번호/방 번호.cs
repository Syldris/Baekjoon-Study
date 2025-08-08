#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string n = sr.ReadLine();
        int[] reslut = new int[10];

        foreach (var item in n)
        {
            reslut[item - '0']++;
        }

        int value = (int)Math.Ceiling((reslut[6] + reslut[9]) / 2.0);
        reslut[6] = value;
        reslut[9] = value;

        sw.WriteLine(reslut.Max());
    }
}
