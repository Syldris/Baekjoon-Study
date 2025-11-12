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

        if (arr[0] == arr.Min())
        {
            sw.Write("ez");
        }
        else if (arr[0] == arr.Max())
        {
            sw.Write("hard");
        }
        else
        {
            sw.Write("?");
        }
    }
}