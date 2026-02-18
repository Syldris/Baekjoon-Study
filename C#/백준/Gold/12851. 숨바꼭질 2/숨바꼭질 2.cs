using System;
using System.Collections.Generic;
using System.Numerics;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int k = int.Parse(inputs[1]);

        int[] visited = new int[100001];
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = -1;
        }

        Queue<(int pos, int day)> queue = new Queue<(int pos, int day)>();

        visited[n] = 0;
        queue.Enqueue((n, 0));

        int minday = int.MaxValue;
        int count = 0;
        while (queue.Count > 0)
        {
            (int pos, int day) = queue.Dequeue();
            if (pos == k)
            {
                if (day <= minday)
                {
                    minday = Math.Min(minday, day);
                    count++;
                }
            }
            if (day > minday)
            {
                break;
            }
            if (pos * 2 <= 100000)
            {
                int teleportPos = pos * 2;
                if (visited[teleportPos] == -1 || visited[teleportPos] == day + 1)
                {
                    queue.Enqueue((teleportPos, day + 1));
                    visited[teleportPos] = day + 1;
                }
            }
            if (pos > 0)
            {
                if (visited[pos - 1] == -1 || visited[pos - 1] == day +1)
                {
                    queue.Enqueue((pos - 1, day + 1));
                    visited[pos - 1] = day + 1;
                }
            }
            if (pos < 100000)
            {
                if (visited[pos + 1] == -1 || visited[pos + 1] == day + 1)
                {
                    queue.Enqueue((pos + 1, day + 1));
                    visited[pos + 1] = day + 1;
                }
            }
        }
        Console.WriteLine(minday);
        Console.WriteLine(count);
    }
}
