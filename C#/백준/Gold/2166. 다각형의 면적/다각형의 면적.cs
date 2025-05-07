using System;
using System.Text;
using System.IO;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        (double x, double y)[] pos = new (double x, double y)[n];
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            double x = double.Parse(input[0]);
            double y = double.Parse(input[1]);
            pos[i] = (x, y);
        }

        double value = 0;

        for (int i = 0; i < n; i++)
        {
            (double x1, double y1) = pos[i];
            (double x2, double y2) = pos[i + 1 == n ? 0 : i + 1];
            value += (x1 * y2 - x2 * y1);
        }

        double result = Math.Round(Math.Abs(value/2),2);
        Console.WriteLine(result.ToString("F1"));

    }
}
