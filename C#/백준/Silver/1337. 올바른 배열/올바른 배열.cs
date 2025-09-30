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
        int result = 5;

        for (int i = 0; i < n; i++)
        {
            int value = 1;
            for (int j = i+1; j < n; j++)
            {
                if (arr[j] - arr[i] >= 5)
                {
                    break;
                }
                value++;
            }
            result = Math.Min(result, 5 - value);
        }
        sw.WriteLine(result);
    }
}
