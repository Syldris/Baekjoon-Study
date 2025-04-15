using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);
        List<int>[] graph = new List<int>[n+1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);
            graph[v].Add(u);
        }

        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[n+1];
        int[] hacking = new int[n+1];

        for (int i = 1; i <= n; i++)
        {
            hacking[i] =BFS(i);
            reset();
        }

        int maxValue = hacking.Max();

        List<int> output = hacking.Select((value, index)
            => new { value, index }).Where(x => x.value == maxValue).
            Select(x => x.index).OrderBy(x => x).ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var item in output)
        {
            sb.AppendLine(item.ToString());
        }

        Console.WriteLine(sb.ToString());

        int BFS(int node)
        {
            visited[node] = true;
            queue.Enqueue(node);
            int count = 0;
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
                count++;
                foreach (int item in graph[number])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
            return count;
        }

        void reset()
        {
            for (int i = 0; i <= n;i++)
            {
                visited[i] = false;
            }
        }
    }
}
