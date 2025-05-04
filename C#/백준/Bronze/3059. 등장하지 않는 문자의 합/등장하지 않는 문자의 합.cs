using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int value = 2015;
            string line = Console.ReadLine();
            HashSet<int> HashSet = new HashSet<int>();
            foreach (char c in line)
            {
                if (!HashSet.Contains(c))
                {
                    HashSet.Add(c);
                    value -= c;
                }
            }
            Console.WriteLine(value);
        }
    }
}