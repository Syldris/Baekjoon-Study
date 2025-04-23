using System;
using System.Text;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int start = 0, end = n - 1;

        int minValue = int.MaxValue;

        int a = 0; 
        int b = 0;

        while (start < end)
        {
            int value = arr[start] + arr[end];

            if (Math.Abs(value) < minValue)
            {
                minValue = Math.Abs(value);
                a = arr[start];
                b = arr[end];
            }

            if (value == 0)
            {
                minValue = 0;
                break;
            }
            else if(value < 0)
            {
                start++;
            }
            else if(value > 0) 
            {
                end--;
            }
        }

        Console.WriteLine($"{a} {b}");
    }
}