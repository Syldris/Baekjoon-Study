#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        decimal[] arr = new decimal[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = decimal.Parse(sr.ReadLine());
        }
        Array.Sort(arr);

        decimal value = 0;
        for (int i = k; i < n - k; i++)
        {
            value += arr[i];
        }
        sw.WriteLine($"{value / (n - 2 * k):F2}");

        value += arr[k] * k;
        value += arr[n - k - 1] * k;
        sw.WriteLine($"{value / n:F2}");
    }
}