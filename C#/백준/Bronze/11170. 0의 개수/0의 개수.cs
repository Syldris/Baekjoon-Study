#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);

            int result = 0;

            for (int i = start; i <= end; i++)
            {
                int value = i;

                while (value >= 10)
                {
                    if (value % 10 == 0)
                        result++;
                    value /= 10;
                }

                if (value % 10 == 0)
                    result++;
            }
            sw.WriteLine(result);
        }
    }
}