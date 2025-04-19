using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int count = 0;
        foreach (var item in arr)
        {
            count += item;
        }
        if (count >= 100)
            Console.WriteLine("OK");
        else
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr.Min())
                    Console.WriteLine(i == 0 ? "Soongsil" : i == 1 ? "Korea" : "Hanyang");
            }
        }
    }
}
