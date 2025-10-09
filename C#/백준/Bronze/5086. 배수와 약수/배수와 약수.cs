#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            if (a == 0 && b == 0)
            {
                return;
            }

            if (b % a == 0)
            {
                sw.WriteLine("factor");
            }
            else if (a % b == 0)
            {
                sw.WriteLine("multiple");
            }
            else
            {
                sw.WriteLine("neither");
            }
        }
    }
}