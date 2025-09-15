#nullable disable
using System;
using System.Security.Claims;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int t = 1; t <= n; t++)
        {
            int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).Skip(1).ToArray();
            Array.Sort(arr);
            int max = arr[^1];
            int min = arr[0];
            int gap = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                gap = Math.Max(gap, arr[i] - arr[i-1]);
            }
            sw.WriteLine($"Class {t}");
            sw.WriteLine($"Max {max}, Min {min}, Largest gap {gap}");
        }
    }
}
