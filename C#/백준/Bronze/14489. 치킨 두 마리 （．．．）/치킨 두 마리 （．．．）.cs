using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int a = int.Parse(inputs[0]);
        int b = int.Parse(inputs[1]);
        int c = int.Parse(Console.ReadLine());
        if(a + b >= c * 2)
        {
            Console.Write(a + b - c * 2);
        }
        else
        {
            Console.Write(a + b);
        }
    }
}