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
        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split('-');
            int day = int.Parse(input[1]);
            if (day <= 90)
            {
                value++;
            }
        }
        sw.Write(value);
    }
}
