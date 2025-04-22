using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        List<(int computer, int cost)>[] graph = new List<(int, int)>[n+1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }
        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            graph[a].Add((b, cost));
            graph[b].Add((a, cost));
        }

        PriorityQueue<(int computer, int cost), int> queue = new PriorityQueue<(int, int), int>();
        queue.Enqueue((1, 0), 0);

        bool[] visited = new bool[n + 1];

        int totalCost = 0;

        while (queue.Count > 0)
        {
            (int computer, int cost) = queue.Dequeue();

            if (visited[computer])
                continue;

            visited[computer] = true;
            totalCost += cost;
            foreach (var next in graph[computer])
            {
                if (!visited[next.computer])
                {
                    queue.Enqueue((next.computer, next.cost), next.cost);
                }
            }
        }

        Console.WriteLine(totalCost);
    }
}