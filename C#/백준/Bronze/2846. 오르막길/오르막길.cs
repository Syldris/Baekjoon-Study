#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int min = arr[0];
        int value = 0;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > arr[i-1])
            {

                value = Math.Max(value, arr[i] - min);
            }
            else
            {
                min = arr[i];
            }
        }
        sw.Write(value);
    }
}
