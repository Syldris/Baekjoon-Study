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
        int[] arr = new int[3];
        for (int i = 0; i < 3; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }
        Array.Sort(arr);
        sw.Write(arr[0] + arr[1] == arr[2] ? 1 : 0);
    }
}
