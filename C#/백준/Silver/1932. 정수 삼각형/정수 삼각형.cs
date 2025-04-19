using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < inputs.Length; j++)
            {
                arr[i, j] = inputs[j];
            }
        }
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if(j >= 1)
                {
                    arr[i, j] += Math.Max(arr[i - 1, j - 1], arr[i - 1, j]);
                }
                else
                    arr[i, j] += arr[i - 1, j];
                
            }
        }

        int max = 0;
        for (int i = 0; i < n; i++)
        {
            max = Math.Max(max, arr[n - 1, i]);
        }

        Console.WriteLine(max);
    }
}
