#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int result = 0;
        int[] arr = new int[3];
        for (int i = 0; i < 3; i++)
        {
            int n = int.Parse(sr.ReadLine());
            int bit = n & 0b1111;
            arr[i] = bit;
        }

        result = arr[0] << 8 | arr[1] << 4 | arr[2];
        sw.WriteLine($"{result:D4}");
    }
}
