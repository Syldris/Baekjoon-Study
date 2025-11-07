#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int max = 0;
        int result = 0;
        string text = "";

        for (int i = 0; i < n; i++)
        {
            string name = sr.ReadLine();
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            int value = 0;
            while (b >= a)
            {
                int cur = b / a;
                value += cur;
                b += cur * 2 - cur * a;
            }
            result += value;
            if (value > max)
            {
                text = name;
                max = value;
            }
        }
        sw.WriteLine(result);
        sw.WriteLine(text);
    }
}