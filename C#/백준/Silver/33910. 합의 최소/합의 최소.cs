#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int min = int.MaxValue;
        long result = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            min = Math.Min(min, arr[i]);
            result += min;
        }
        sw.Write(result);
    }
}
