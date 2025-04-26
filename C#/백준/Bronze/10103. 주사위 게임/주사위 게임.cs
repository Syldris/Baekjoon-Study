using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int a = 100, b = 100;
        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split();
            int num1 = int.Parse(line[0]);
            int num2 = int.Parse(line[1]);

            if(num1 > num2)
                b -= num1;
            else if(num1 < num2)
                a -= num2;
        }
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}