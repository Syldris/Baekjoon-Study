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
        int c = int.Parse(inputs[2]);
        Console.WriteLine((a + b) % c);
        Console.WriteLine(((a % c) + (b % c)) % c);
        Console.WriteLine((a * b) % c);
        Console.WriteLine(((a % c) * (b % c)) % c);
    }
}