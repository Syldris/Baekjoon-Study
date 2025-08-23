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
        int[] arr = new int[11];

        for (int i = 2; i < 11; i++)
        {
            int value = i - 1;
            arr[i] = arr[i-1] + value;
        }

        sw.Write(arr[n]);
    }
}
