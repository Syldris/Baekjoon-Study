#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        List<(int l, int r)> list = new List<(int, int)>();

        for (int i = 0; i < n; i++)
        {
            if (arr[i] != i + 1)
            {
                int index = i + 1;
                while (index < n && arr[index] != i + 1)
                {
                    index++;
                }
                Array.Reverse(arr, i, index - i + 1);
                list.Add((i + 1, index + 1));
            }
        }
        sw.WriteLine(list.Count);
        foreach ((int l, int r) in list)
        {
            sw.WriteLine($"{l} {r}");
        }
    }
}