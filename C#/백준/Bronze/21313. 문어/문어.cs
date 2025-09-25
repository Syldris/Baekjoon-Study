#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        arr[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1] == 1)
            {
                arr[i] = 2;
            }
            else
            {
                arr[i] = 1;
            }
        }
        if(n % 2 == 1)
            arr[^1] = 3;
        sw.Write(String.Join(' ', arr));
    }
}
