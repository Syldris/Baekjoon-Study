#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        List<long> list = new List<long>();

        for (int i = 0; i < 10; i++)
        {
            DFS(i, i);
        }

        list.Sort();

        if (n >= list.Count)
        {
            sw.Write(-1);
        }
        else
        {
            sw.Write(list[n]);
        }

        void DFS(long value, int depth)
        {
            list.Add(value);
            for (int i = 0; i < depth; i++)
            {
                DFS(value * 10 + i, i);
            }
        }

    }
}
