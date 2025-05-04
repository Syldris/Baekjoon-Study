using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int[] arr = new int[n];
        arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(arr);

        Console.WriteLine(arr[k-1]);
    }
}