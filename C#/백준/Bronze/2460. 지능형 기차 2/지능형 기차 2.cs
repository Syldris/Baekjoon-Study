#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int result = 0;
        int value = 0;
        while (true)
        {
            string line = sr.ReadLine();
            if (line == null)
            {
                break;
            }
            string[] input = line.Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            value += b - a;
            result = Math.Max(result, value);
        }
        sw.WriteLine(result);
    }
}