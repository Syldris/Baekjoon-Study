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
        Array.Sort(arr);
        Array.Reverse(arr);
        int value = 1;
        int result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            result = Math.Max(result, arr[i] + value);
            value++;
        }
        sw.Write(result+1);
    }
}
