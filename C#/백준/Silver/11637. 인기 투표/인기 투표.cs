#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int max = 0;
            int sum = 0;
            int index = 0;

            bool win = true;

            for (int i = 1; i <= n; i++)
            {
                int value = int.Parse(sr.ReadLine());
                if (value > max)
                {
                    max = value;
                    index = i;
                    win = true;
                }
                else if (value == max)
                {
                    win = false;
                }
                sum += value;
            }

            if (!win)
            {
                sw.WriteLine("no winner");
                continue;
            }
            sw.WriteLine(max > sum - max ? $"majority winner {index}" : $"minority winner {index}");
        }
    }
}