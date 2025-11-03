#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            List<(int a, int b)> list = new List<(int, int)>();
            for (int i = 1; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (i + j == n)
                    {
                        list.Add((i, j));
                    }
                }
            }
            sw.Write($"Pairs for {n}:");
            for (int i = 0; i < list.Count; i++)
            {
                sw.Write($" {list[i].a} {list[i].b}");
                if (list.Count != 1 && i != list.Count - 1)
                {
                    sw.Write(',');
                }
            }
            sw.WriteLine();
        }
    }
}