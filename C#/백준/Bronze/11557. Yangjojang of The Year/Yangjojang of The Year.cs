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
            (string name, int value)[] school = new (string name, int value)[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = sr.ReadLine().Split();
                school[i] = (input[0], int.Parse(input[1]));
            }

            school = school.OrderByDescending(x => x.value).ToArray();
            sw.WriteLine(school[0].name);
        }
    }
}
