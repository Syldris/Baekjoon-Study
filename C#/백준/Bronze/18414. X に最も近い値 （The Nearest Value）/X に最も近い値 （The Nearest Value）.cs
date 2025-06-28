#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);

        int min = int.MaxValue;
        int value = 0;
        for (int i = b; i <= c; i++)
        {
            if (Math.Abs(a - i) < min)
            {
                min = Math.Abs(a - i);
                value = i;
            }
        }
        sw.Write(value);
    }
}
