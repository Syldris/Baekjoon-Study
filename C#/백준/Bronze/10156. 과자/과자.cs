using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int k = int.Parse(inputs[0]);
        int n = int.Parse(inputs[1]);
        int m = int.Parse(inputs[2]);
        if(k * n - m < 0 )
            Console.WriteLine(0);
        else
            Console.WriteLine(k * n - m);
    }
}