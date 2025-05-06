using System;
using System.Text;
using System.IO;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        BigInteger a = BigInteger.Parse(Console.ReadLine());
        string c = Console.ReadLine();
        BigInteger b = BigInteger.Parse(Console.ReadLine());

        Console.Write(c == "*" ? a * b : a + b);
    }
}
