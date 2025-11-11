#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int test = int.Parse(sr.ReadLine());
        for (int t = 0; t < test; t++)
        {
            int value = int.Parse(sr.ReadLine());
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = sr.ReadLine().Split();
                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);
                value += a * b;
            }
            sw.WriteLine(value);
        }
    }
}