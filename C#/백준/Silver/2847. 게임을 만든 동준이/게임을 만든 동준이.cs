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

        int result = 0;

        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] >= arr[i + 1])
            {
                result += arr[i] - arr[i + 1] + 1;
                arr[i] = arr[i + 1] - 1;
            }
        }
        sw.Write(result);
    }
}