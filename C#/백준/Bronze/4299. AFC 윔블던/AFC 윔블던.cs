using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        short sum = short.Parse(inputs[0]);
        short sub = short.Parse(inputs[1]);

        short a = (short)((sum + sub) / 2);
        short b = (short)(sum - a);
        if (a - b == sub && b >= 0)
            Console.WriteLine($"{a} {b}");
        else
            Console.WriteLine(-1);
    }
}
