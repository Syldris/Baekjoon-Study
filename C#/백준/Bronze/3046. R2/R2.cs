using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int r1 = int.Parse(inputs[0]);
        int s = int.Parse(inputs[1]);
        int r2 = s * 2 - r1;
        Console.WriteLine(r2);
    }
}