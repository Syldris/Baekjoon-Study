#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] sum = new int[51];
        for (int i = 0; i < n; i++)
        {
            sum[arr[i]]++;
        }

        int result = -1;

        for (int i = 0; i < 51; i++)
        {
            if (sum[i] == i)
            {
                result = i;
            }
        }
        sw.Write(result);
    }
}