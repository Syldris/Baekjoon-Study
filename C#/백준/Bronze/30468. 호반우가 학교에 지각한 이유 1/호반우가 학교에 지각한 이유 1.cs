#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int total = 0;
        for (int i = 0; i < 4; i++)
        {
            total += arr[i];
        }
        sw.WriteLine(Math.Max(arr[^1] * 4 - total, 0));
    }
}
