#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr1 = new int[m];
        int[] arr2 = new int[m];
        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            arr1[i] = int.Parse(line[0]);
            arr2[i] = int.Parse(line[1]);
        }

        int six = arr1.Min();
        int one = arr2.Min();

        int result = 0;

        if (six > one * 6)
        {
            result = n * one;
        }
        else
        {
            int v1 = n / 6;
            int v2 = n % 6;

            result = Math.Min(v1 * six + v2 * one, (v1 + 1) * six);
        }

        sw.Write(result);
    }
}