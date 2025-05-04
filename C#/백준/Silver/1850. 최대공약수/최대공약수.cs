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

        ulong a = ulong.Parse(input[0]);
        ulong b = ulong.Parse(input[1]);

        while (b != 0)
        {
            ulong r = a % b;
            a = b;
            b = r;
        }

        Console.WriteLine(new String('1', (int)a));
    }
}