#nullable disable
using System;
using System.Numerics;
using System.Text;
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
        Array.Sort(arr);

        int k = 1;
        int result = arr[^1];

        for (int i = n - 2; i >= 0; i--)
        {
            k++;
            int weight = arr[i] * k;
            if (weight < result)
            {
                continue;
            }
            result = weight;
        }
        sw.Write(result);
    }
}
