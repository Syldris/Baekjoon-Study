#nullable disable
using System;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int value = int.Parse(sr.ReadLine());
        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());
        int result = 0;
        while (a != b)
        {
            if (a == value)
            {
                a = 0;
            }
            a++;
            result++;
        }
        sw.Write(result);
    }
}
