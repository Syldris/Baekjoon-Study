using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        if(a + b + c == 180)
        {
            if (a == 60 && b == 60 & c == 60)
            {
                Console.WriteLine("Equilateral");
            }
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Isosceles");
            }
            else
                Console.WriteLine("Scalene");
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}
