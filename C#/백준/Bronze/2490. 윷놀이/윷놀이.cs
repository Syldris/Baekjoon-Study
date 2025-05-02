using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num0 = 0;
            foreach (var item in line)
            {
                if(item == 0)
                    num0++;
            }
            switch(num0)
            {
                case 0:
                    Console.WriteLine('E');
                    break;
                case 1:
                    Console.WriteLine('A');
                    break;
                case 2:
                    Console.WriteLine('B');
                    break;
                case 3:
                    Console.WriteLine('C');
                    break;
                case 4:
                    Console.WriteLine('D');
                    break;
            }
        }
    }
}