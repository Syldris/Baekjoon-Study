using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int k = int.Parse(inputs[2]);

        Console.WriteLine(Math.Min(m, k) + Math.Min(n - m, n - k));
    }
}