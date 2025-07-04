using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int index = 0;
        for (int i = 0; i < count; i++)
        {
            index = i;
            char[] arr = i.ToString().ToCharArray();   
            foreach (char c in arr)
            {
                index += c - '0';
            }
            if (index == count)
            {
                index = i;
                break;
            }
            index = 0;
        }
        Console.WriteLine(index);
    }
}
