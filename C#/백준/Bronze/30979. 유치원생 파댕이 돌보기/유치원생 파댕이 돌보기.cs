#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int t = int.Parse(sr.ReadLine());   
        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int value = 0;
        foreach (var item in arr)
        {
            value += item;
        }
        sw.Write(value >= t ? "Padaeng_i Happy" : "Padaeng_i Cry");
    }
}
