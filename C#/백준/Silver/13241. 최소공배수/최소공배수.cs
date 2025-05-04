using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        long a = long.Parse(input[0]);
        long b = long.Parse(input[1]);
        long _a = a;
        long _b = b;

        while (b != 0)
        {
            long r = a % b;
            a = b;
            b = r;
        }

        long num = (_a / a) * _b;
        
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        sw.Write(num);
        sw.Close();
    }
}