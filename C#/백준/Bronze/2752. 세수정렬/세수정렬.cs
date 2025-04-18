using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript1
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Array.Sort(arr);
        foreach (var item in arr)
        {
            Console.Write($"{item} ");
        }
    }
}
