using System;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int num1 = array[0];
        int num2 = array[1];

        int max = 0;
        int min = 0;
        for (int i = num1; i >= 1; i--)
        {
            if(num1% i == 0 && num2 % i == 0)
            {
                max = i;
                break;
            }
        }
        for (int i = 1; i < 10000; i++)
        {
            int index = num1 * i;
            for (int j = 1; j <10000; j++)
            {
                int index2 = num2 * j;
                if(index == index2)
                {
                    min = index;
                    goto outerLoop;
                }
            }
        }
        outerLoop:
        Console.WriteLine(max);
        Console.WriteLine(min);
    }
}