#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arr = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            arr[i] = i;
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int start = line[0];
            int end = line[1];
            int mid = line[2];

            int index = start;
            int[] startarr = arr.Skip(start).Take(mid-start).ToArray();
            int[] midarr = arr.Skip(mid).Take(end - mid + 1).ToArray();

            foreach (var item in midarr)
            {
                arr[index++] = item;
            }
            foreach (var item in startarr)
            {
                arr[index++] = item;
            }
        }

        sw.Write(String.Join(' ', arr.Skip(1)));
    }
}
