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
            if (n % i == 0)
            {
                result += i;
            }
        }
        sw.Write(result * 5 - 24);
    }
}
