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
        int m = int.Parse(inputs[1]);
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);

        int start = 0, end = 0;
        int minValue = int.MaxValue;

        while (start <= end && end < n)
        {
            int value = arr[end] - arr[start];
            if(value == m)
            {
                minValue = value;
                break;
            }
            if (value > m)
            {
                minValue = Math.Min(value, minValue);
                start++;
            }
            else
            {
                end++;
            }
        }
        Console.WriteLine(minValue);
    }
}