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

        long[] sum = new long[302];
        long[] arr = new long[301];
        int n = int.Parse(sr.ReadLine());

        sum[1] = 1;
        for (int i = 1; i <= 300; i++)
        {
            sum[i+1] = sum[i] + i+1;
            arr[i] = arr[i-1] + i * sum[i + 1];
        }

        for (int i = 0; i < n; i++)
        {
            int a = int.Parse(sr.ReadLine());
            sw.WriteLine(arr[a]);
        }
    }
}
