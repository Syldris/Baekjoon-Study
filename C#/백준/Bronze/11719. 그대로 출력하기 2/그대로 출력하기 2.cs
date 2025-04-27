using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        while (true)
        {
            string line = Console.ReadLine();
            if(line == null) 
                break;
            Console.WriteLine(line);
        }
    }
}