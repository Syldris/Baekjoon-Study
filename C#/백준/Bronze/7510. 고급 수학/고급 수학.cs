using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= n; i++)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxValue = arr.Max();
            int maxIndex = Array.IndexOf(arr, maxValue);
            maxValue *= maxValue;
            int value = 0;

            for(int j = 0; j < 3; j++)
            {
                if(j != maxIndex)
                {
                    value += arr[j] * arr[j];
                }
            }
            sb.AppendLine($"Scenario #{i}:");
            sb.AppendLine(maxValue == value ? "yes" : "no");
            sb.AppendLine();
        }
        Console.WriteLine(sb);
    }
}
