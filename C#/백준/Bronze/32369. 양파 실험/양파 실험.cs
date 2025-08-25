#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int a = int.Parse(input[1]);
        int b = int.Parse(input[2]);

        int max = 1;
        int min = 1;

        for (int i = 0; i < n; i++)
        {
            max += a;
            min += b;
            if (max == min)
            {
                min--;
            }
            if (min > max)
            {
                (min, max) = (max, min);
            }
        }
        sw.WriteLine($"{max} {min}");
    }
}
