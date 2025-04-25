using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        while(true)
        {
            string line = Console.ReadLine();
            if(line == "#")
                break;

            line = line.ToLower();
            int count = 0;
            foreach (var item in line)
            {
                switch(item)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        count++;
                        break;
                }
            }
            Console.WriteLine(count);
        }    
    }
}
