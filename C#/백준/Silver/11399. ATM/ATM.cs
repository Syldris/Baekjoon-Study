using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Array.Sort(arr);

        int p = 0;
        int min = 0;

        foreach (var item in arr)
        {
            p += item;
            min += p;
        }
        Console.Write(min);
    }
}
