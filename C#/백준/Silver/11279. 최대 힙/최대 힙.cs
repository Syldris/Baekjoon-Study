using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        PriorityQueue<long, long> queue = new PriorityQueue<long, long>();
        StringBuilder sb = new StringBuilder();
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if(number == 0)
            {
                if(queue.TryDequeue(out long a, out long b))
                {
                    sb.AppendLine(a.ToString());
                }
                else
                {
                    sb.AppendLine("0");
                }
            }
            else
            {
                queue.Enqueue(number, -number);
            }
        }
        Console.WriteLine(sb.ToString());
    }
}
