#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            int value = i;
            int k = 0;
            while (value >= 10)
            {
                k += value % 10;
                value = value / 10;
            }
            k += value;
            if (i % k == 0)
            {
                result++;
            }
        }
        sw.Write(result);
    }
}
