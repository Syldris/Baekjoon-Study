using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int L = int.Parse(input[0]);
        int P = int.Parse(input[1]);
        int value = L * P;

        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] -= value;
        }
        Console.WriteLine(String.Join(" ", arr));
    }
}
