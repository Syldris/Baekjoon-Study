using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        Console.WriteLine(Sqrt(n));
    }

    static BigInteger Sqrt(BigInteger n)
    {
        if (n == 0 || n == 1) return n;

        BigInteger left = 0;
        BigInteger right = n;
        BigInteger mid;
        while (left <= right)
        {
            mid = (left + right) / 2;
            BigInteger number = mid * mid;

            if (number == n)
            {
                return mid;
            }
            else if (number < n)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return right;
    }
}
