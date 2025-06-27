#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] outputs = new int[n];

        int value = 0;
        for (int i = 0; i < n; i++)
        {
            int curvalue = arr[i] * (i + 1);
            outputs[i] = curvalue - value;
            value = curvalue;
        }

        sw.Write(String.Join(' ', outputs));
    }
}
