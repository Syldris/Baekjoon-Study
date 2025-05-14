using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int bigBox = int.Parse(Console.ReadLine());
        int smallBox = int.Parse(Console.ReadLine());
        Console.WriteLine((bigBox * 8 + smallBox * 3) - 28);
    }
}
