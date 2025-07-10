#nullable disable
using System;
using System.Collections;
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
        for (int i = 0; i < m; i++)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            arr = arr.OrderBy(x => Math.Abs(x)).ToArray();

            List<int> plus = new List<int>();
            List<int> minus = new List<int>();
            int zeroCount = 0;
            foreach (var item in arr)
            {
                if (item < 0)
                {
                    minus.Add(item);
                }
                else if (item > 0)
                {
                    plus.Add(item);
                }
                else
                {
                    zeroCount++;
                }
            }

            List<int> list = new List<int>();
            list.AddRange(plus);

            if (minus.Count % 2 == 0)
            {
                list.AddRange(minus);
            }
            else
            {
                list.AddRange(minus.Skip(1));
            }

            if (list.Count == 0)
            {
                if (zeroCount > 0)
                {
                    sw.WriteLine(0);
                }
                else
                {
                    sw.WriteLine(minus[0]);
                }
                continue;
            }

            BigInteger result = 1;
            foreach (var item in list)
            {
                result *= item;
            }
            sw.WriteLine(result);
        }
    }
}
