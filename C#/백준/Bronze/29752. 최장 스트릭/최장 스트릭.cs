#nullable disable
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int value = 0;
        int result = 0;

        foreach (var item in arr)
        {
            if (item != 0)
            {
                value++;
                result = Math.Max(result, value);
            }
            else
            {
                value = 0;
            }
        }
        sw.Write(result);
    }
}