using System;
using System.Text;
using System.IO;
public class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        int a = 0;
        int b = 0;

        for (int i = 0; i< input.Length; i++)
        {
            if (input[i] == '0')
            {
                if (i == 1)
                    a *= 10;
                else
                    b *= 10;
            }
            else
            {
                if (i == 0)
                    a += input[i] - '0';
                else
                    b += input[i] - '0';
            }
        }

        Console.WriteLine(a + b);
    }
}
