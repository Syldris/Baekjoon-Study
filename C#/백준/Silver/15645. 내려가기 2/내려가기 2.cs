using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int[] min = new int[3];
        int[] max = new int[3];

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if(i == 0)
            {
                min = input.ToArray();
                max = input.ToArray();
            }
            else
            {
                int[] tempMin = new int[3];
                int[] tempMax = new int[3];

                tempMin[0] = Math.Min(min[0], min[1]) + input[0];
                tempMax[0] = Math.Max(max[0], max[1]) + input[0];

                tempMin[1] = Math.Min(Math.Min(min[0], min[1]), min[2]) + input[1];
                tempMax[1] = Math.Max(Math.Max(max[0], max[1]), max[2]) + input[1];

                tempMin[2] = Math.Min(min[1], min[2]) + input[2];
                tempMax[2] = Math.Max(max[1], max[2]) + input[2];

                min = tempMin;
                max = tempMax;
            }
        }

        Console.WriteLine($"{max.Max()} {min.Min()}");
    }
}
