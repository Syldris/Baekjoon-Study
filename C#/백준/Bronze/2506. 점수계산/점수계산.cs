using System;
using System.Text;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int value = 1;
        int result = 0;

        for (int i = 0; i < n; i++)
        {
            if(arr[i] == 1)
            {
                result += value;
                value++;
            }
            else
            {
                value = 1;
            }
        }
        Console.WriteLine(result);
    }
}
