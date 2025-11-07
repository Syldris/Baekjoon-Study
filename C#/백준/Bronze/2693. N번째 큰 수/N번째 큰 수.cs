#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr);
            sw.WriteLine(arr[^3]);
        }
    }
}