#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += Math.Abs(arr[i] - arr.Max());
        }
        sw.Write(sum);
    }
}
