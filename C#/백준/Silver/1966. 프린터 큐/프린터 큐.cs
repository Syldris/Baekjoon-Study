using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<(int index, int priority)> queue = new Queue<(int, int)>();
            for (int j = 0; j < arr.Length; j++)
            {
                queue.Enqueue((j, arr[j]));
            }

            int count = 0;

            while (queue.Count > 0)
            {
                (int index, int priority) = queue.Dequeue();
                if(priority < arr.Max())
                {
                    queue.Enqueue((index,priority));
                }
                else
                {
                    count++;
                    arr[index] = 0;
                    if(index == m)
                        break;
                }
            }
            Console.WriteLine(count);
        }
    }
}
