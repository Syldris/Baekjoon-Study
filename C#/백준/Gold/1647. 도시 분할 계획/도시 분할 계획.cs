using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();

        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        List<(int pos, int cost)>[] city = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            city[i] = new List<(int, int)>();

        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int from = int.Parse(line[0]);
            int to = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            city[from].Add((to, cost));
            city[to].Add((from, cost));
        }

        int totalCost = 0;
        int maxCost = 0;
        bool[] visited = new bool[n + 1];

        PriorityQueue<(int pos, int cost), int> queue = new();
        queue.Enqueue((1, 0), 0);
        while (queue.Count > 0)
        {
            (int pos, int cost) = queue.Dequeue();

            if (visited[pos])
                continue;
            visited[pos] = true;
            
            totalCost += cost;
            maxCost = Math.Max(maxCost, cost);

            foreach (var next in city[pos])
            {
                if (!visited[next.pos])
                    queue.Enqueue((next.pos, next.cost), next.cost);
            }
        }
        Console.WriteLine(totalCost - maxCost);
    }
}