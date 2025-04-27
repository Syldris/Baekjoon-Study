using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int count = 0;
        int num = 0;

        count = 1;
        foreach (var item in input)
        {
            num += item - '0';
        }

        while (num >= 10)
        {
            string strNum = num.ToString();
            count++;
            num = 0;
            foreach (var item in strNum)
            {
                num += item - '0';
            }
            strNum = num.ToString();
        }
        Console.WriteLine(input.Length == 1 ? 0 : count);
        Console.WriteLine(num % 3 == 0 ? "YES" : "NO");
    }
}