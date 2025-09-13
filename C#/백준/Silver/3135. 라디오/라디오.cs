#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int result = Math.Abs(a - b);

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int cur = int.Parse(sr.ReadLine());
            int value = Math.Abs(cur - b) + 1;
            result = Math.Min(result, value);
        }
        sw.Write(result);

    }
}
