#nullable disable
using System;
using System.Text;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int result = 1;
            int value = int.Parse(sr.ReadLine());
            while (result * result + result <= value)
            {
                result++;
            }
            sw.WriteLine(--result);
        }
    }
}
