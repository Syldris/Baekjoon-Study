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

        while (true)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            if (arr.All(x => x == 0))
            {
                break;
            }
            sw.WriteLine($"{arr[2] - arr[1]} {arr[3] - arr[0]}");
        }
    }
}