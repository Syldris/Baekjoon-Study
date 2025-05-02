using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int burger1 = int.Parse(Console.ReadLine());
        int burger2 = int.Parse(Console.ReadLine());
        int burger3 = int.Parse(Console.ReadLine());

        int cola = int.Parse(Console.ReadLine());
        int cider = int.Parse(Console.ReadLine());

        int minValue = Math.Min(Math.Min(burger1, burger2),burger3) + Math.Min(cola,cider);
        Console.WriteLine(minValue - 50);
    }
}