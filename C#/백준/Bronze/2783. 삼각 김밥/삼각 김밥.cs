#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        double result = 0;
        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        result = Math.Max(result, (double)b / a);
        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            result = Math.Max(result, (double)y / x);
        }

        sw.Write($"{1000/result:F2}");
    }
}
