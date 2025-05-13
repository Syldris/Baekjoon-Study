using System;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int count = 0;
        int output = 0;
        for (int i = 1; i < 100000000; i++)
        {
            string text = i.ToString();
            if(text.Contains("666"))
                count++;
            if(n == count)
            {
                output = i;
                break;
            }
        }
        Console.WriteLine(output);
    }
}
