using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int start = 0, end = 1;

        int count = 0; 
        while (true)
        {
            int number = 0;
            if (start > n || end > n)
                break;

            for (int i = start; i <= end; i++)
            {
                number += i;
            }
            if(number < n)
            {
                end++;
            }
            else if(number > n)
            {
                start++;
            }
            else if (number == n)
            {
                count++;
                end++;
            }
        }
        Console.WriteLine(count);

    }
}
