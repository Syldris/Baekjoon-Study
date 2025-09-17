#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[,] arr = new int[m, n];
        for (int y = 0; y < n; y++)
        {
            int[] line = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int x = 0; x < m; x++)
            {
                arr[x, y] = line[x];
            }
        }


        int result = 0;
        for (int start = 0; start < m; start++)
        {
            for (int mid = start + 1; mid < m; mid++)
            {
                for (int end = mid + 1; end < m; end++)
                {
                    int value = 0;

                    for (int people = 0; people < n; people++)
                    {
                        value += Math.Max(Math.Max(arr[start, people], arr[mid, people]), arr[end,people]);
                    }
                    result = Math.Max(result, value);
                }
            }
        }

        sw.Write(result);
    }
}
