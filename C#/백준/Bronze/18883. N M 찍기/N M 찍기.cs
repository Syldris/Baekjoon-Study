#nullable disable
using System;
using System.Collections;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        for (int y = 0; y < n; y++)
        {
            int value = y * m + 1;
            List<int> list = new List<int>();

            for (int x = 0; x < m; x++)
            {
                list.Add(value + x);
            }

            sw.WriteLine(String.Join(' ', list));
        }
    }
}