using System;
using System.Collections;
using System.Numerics;
using System.Text;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        PriorityQueue<long,long> queue = new PriorityQueue<long,long>();
        for (int i = 0; i < n; i++)
        {
            long value = long.Parse(sr.ReadLine());
            queue.Enqueue(value, value);
        }

        long result = 0;
        while (queue.Count >= 2)
        {
            long a = queue.Dequeue();
            long b = queue.Dequeue();

            long c = a + b;
            result += c;
            queue.Enqueue(c,c);
        }
        sw.Write(result);
    }
}