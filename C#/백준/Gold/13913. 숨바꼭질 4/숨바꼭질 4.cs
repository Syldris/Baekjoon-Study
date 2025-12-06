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

        bool[] visited = new bool[100001];
        int[] prev = new int[100001];

        Queue<(int pos, int day)> queue = new Queue<(int pos, int day)>();

        visited[n] = true;
        queue.Enqueue((n, 0));
        while (queue.Count > 0)
        {
            (int pos, int day) = queue.Dequeue();
            if (pos == k)
            {
                Console.WriteLine(day);
                Stack<int> stack = new Stack<int>();
                for(int i = k; i !=n; i = prev[i])
                {
                    stack.Push(i);
                }
                stack.Push(n);
                Console.WriteLine(String.Join(" ", stack));
                return;
            }
            if (pos*2 <= 100000)
            {
                int teleportPos = pos * 2;
                if (!visited[teleportPos])
                {
                    queue.Enqueue((teleportPos, day + 1));
                    visited[teleportPos] = true;
                    prev[teleportPos] = pos;
                }
            }
            if(pos < 100000)
            {
                if (!visited[pos+1])
                {
                    queue.Enqueue((pos + 1, day + 1));
                    visited[pos + 1] = true;
                    prev[pos+1] = pos;
                }
            }
            if(pos > 0)
            {
                if(!visited[pos-1])
                {
                    queue.Enqueue((pos - 1, day + 1));
                    visited[pos - 1] = true;
                    prev[pos - 1] = pos;
                }
            }
        }

    }
}
