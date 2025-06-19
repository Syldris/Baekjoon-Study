#nullable disable
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int value = int.Parse(sr.ReadLine());
        int maxValue = value;

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            value += a;
            value -= b;

            maxValue = Math.Max(value, maxValue);
            if(value < 0)
            {
                sw.Write(0);
                return;
            }
        }
        sw.Write(maxValue);
    }
}