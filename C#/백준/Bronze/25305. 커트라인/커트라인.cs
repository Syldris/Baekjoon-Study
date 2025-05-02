using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int k = int.Parse(inputs[1]);
        int[] arr = new int[n];
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(arr);
        Array.Reverse(arr);
        Console.WriteLine(arr[k - 1]);
    }
}