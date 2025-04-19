using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        BigInteger a = BigInteger.Parse(inputs[0]);
        BigInteger b = BigInteger.Parse(inputs[1]);
        Console.WriteLine(a + b);
    }
}
