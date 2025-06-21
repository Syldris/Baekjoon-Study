#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int value = 1;
        for (int i = a; i <= b; i++)
        {
            int sum = 0;
            for (int j = 1; j <= i; j++)
            {
                sum += j;
            }
            value = (value * sum) % 14579;
        }
        sw.Write(value);
    }
}
