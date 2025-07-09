using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        Queue<int> queue = new Queue<int>();

        for (int i = 1; i <= n; i++)
        {
            queue.Enqueue(i);
        }
        List<int> list = new List<int>();
        int count = 1;
        while (queue.Count > 0)
        {
            if(count >= k)
            {
                list.Add(queue.Dequeue());
                count = 0;
            }
            else
            {
                queue.Enqueue(queue.Dequeue());
            }
            count++;
        }
        Console.WriteLine($"<{String.Join(", ",list)}>");
    }
}
