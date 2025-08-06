#nullable disable
using System;
using System.Net.Sockets;
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
        long result = 0;
        for (int i = 1; i < n; i++)
        {
            result += arr[i] - arr[i - 1];
        }
        result += arr[^1] - arr[0];
        sw.Write(result);
    }
}
