#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] sum = new int[n];
        for (int i = 1; i < n; i++)
        {
            sum[i] = sum[i - 1] + Math.Abs(arr[i] - arr[i - 1]);
        }

        for (int i = 0; i < q; i++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            sw.WriteLine(sum[end - 1] - sum[start - 1]);
        }
    }
}