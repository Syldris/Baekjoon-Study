#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int k = int.Parse(input[0]);
            int a = int.Parse(input[1]);
            int b = int.Parse(input[2]);

            if (k == 0 && a == 0 && b == 0)
            {
                break;
            }
            float sec1 = ((float)k / a);
            float sec2 = ((float)k / b);

            int value = (int)(Math.Round((sec1 - sec2) * 3600));

            int hour = value / 3600;
            int minute = (value / 60) % 60;
            int second = value % 60;

            sw.WriteLine($"{hour:D1}:{minute:D2}:{second:D2}");
        }
    }

}