using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int num1 = 0;
        int num2 = 0;
        foreach (var item in arr)
        {
            if(item == 1)
                num1++;
            if(item == 2) 
                num2++;
        }
        Console.WriteLine(num1 > num2 ? "1" : "2");
    }
}