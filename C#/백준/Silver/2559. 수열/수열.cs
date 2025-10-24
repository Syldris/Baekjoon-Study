#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int start = 0; int end = k;

        int value = 0;
        for (int i = start; i < end; i++)
        {
            value += arr[i];
        }

        int result = value;

        while (n != end)
        {
            value -= arr[start];
            value += arr[end];
            result = Math.Max(result, value);
            start++;
            end++;
        }

        sw.Write(result);
    }
}