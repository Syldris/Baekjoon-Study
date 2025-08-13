#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(arr);
        sw.WriteLine(Math.Abs(arr[3] + arr[0] - arr[1] - arr[2]));
    }
}
