#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        if (arr[1] - arr[0] == arr[2] - arr[1])
        {
            sw.Write(arr[^1] + arr[1] - arr[0]);
        }
        else
        {
            sw.Write(arr[^1] * (arr[1] / arr[0]));
        }
    }
}