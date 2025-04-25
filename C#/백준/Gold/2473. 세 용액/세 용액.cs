using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Console.ReadLine().Split().Select(long.Parse).ToArray();

        Array.Sort(arr);


        (long a, long b, long c) = (0, 0, 0);
        long value = long.MaxValue;


        for (int i = 1; i < n-1; i++)
        {
            long start = 0, mid = i, end = n - 1;
            while (start < end)
            {
                long number = arr[start] + arr[mid] + arr[end];

                if (Math.Abs(number) < value)
                {
                    value = Math.Abs(number);
                    (a, b, c) = (arr[start], arr[mid], arr[end]);
                }

                if(number == 0) break;
                if(number > 0)
                {
                    end--;
                    if(mid == end)
                        break;
                }
                else
                {
                    start++;
                    if(start == mid)
                        break;
                }
            }
            
        }
        Console.WriteLine($"{a} {b} {c}");
    }
}
