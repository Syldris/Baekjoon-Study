#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int a = int.Parse(line[0]);
        int b = int.Parse(line[1]);

        string[] input = sr.ReadLine().Split();
        int c = int.Parse(input[0]);
        int d = int.Parse(input[1]);

        int value = 0;
        int result = 0;

        while (value != b)
        {
            if (value < a)
            {
                result += c;
            }
            else
            {
                result += d;
            }
            value++;
        }
        sw.WriteLine(result);
    }
}
