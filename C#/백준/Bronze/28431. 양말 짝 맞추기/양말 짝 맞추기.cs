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


        Dictionary<int, int> freq = new Dictionary<int, int>();
        for (int i = 0; i < 5; i++)
        {
            int num = int.Parse(sr.ReadLine());

            if (freq.TryGetValue(num, out int value))
            {
                freq[num]++;
            }
            else
            {
                freq.Add(num, 1);
            }
        }
        List<int> list = freq.Where(x => x.Value == 1).Select(x => x.Key).ToList();

        if (list.Count > 0)
        {
            sw.Write(list[0]);
        }
        else
        {
            list = freq.Where(x => x.Value == 3).Select(x => x.Key).ToList();
            if (list.Count > 0)
                sw.Write(list[0]);
            else
            {
                list = freq.Where(x => x.Value == 5).Select(x => x.Key).ToList();
                sw.Write(list[0]);
            }
        }
    }
}
