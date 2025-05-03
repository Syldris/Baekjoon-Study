using System;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string c = Console.ReadLine();

        if(int.TryParse(c, out int num))
        {
            Console.WriteLine(FizzBuzz(num + 1));
        }
        else if(int.TryParse(b, out int num2))
        {
            Console.WriteLine(FizzBuzz(num2 + 2));
        }
        else if (int.TryParse(a, out int num3))
        {
            Console.WriteLine(FizzBuzz(num3 + 3));
        }
    }

    static string FizzBuzz(int index)
    {
        if(index % 3 == 0 && index % 5 == 0)
        {
            return "FizzBuzz";
        }
        else if(index % 3 == 0 && index % 5 != 0)
        {
            return "Fizz";
        }
        else if (index % 3 != 0 && index % 5 == 0)
        {
            return "Buzz";
        }
        else
        {
            return index.ToString();
        }
    }
}
