#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int value = 0;
        for (int a = 1; a <= 500; a++)
        {
            for (int b = 1; b <= 500; b++)
            {
                if (a * a - b * b == n)
                {
                    value++;
                }
            }
        }
        sw.Write(value);
    }
}
