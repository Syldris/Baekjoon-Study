using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int V = int.Parse(inputs[0]);
        int E = int.Parse(inputs[1]);
        List<(int node, int dist)>[] graph = new List<(int, int)>[V + 1];
        for (int i = 1; i <= V; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < E; i++)
        {
            string[] line = Console.ReadLine().Split();
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);
            int dist = int.Parse(line[2]);
            graph[u].Add((v, dist));
            graph[v].Add((u, dist));
        }

        PriorityQueue<(int node, int dist), int> queue = new PriorityQueue<(int, int), int>();
        bool[] visited = new bool[V + 1];

        queue.Enqueue((1,0),0);
        int totalDistacne = 0;
        while (queue.Count > 0)
        {
            (int node, int dist) = queue.Dequeue();
            if(visited[node]) continue;
            visited[node] = true;
            totalDistacne += dist;
            foreach (var next in graph[node])
            {
                if (!visited[next.node])
                {
                    queue.Enqueue((next.node, next.dist), next.dist);
                }
            }
        }
        Console.WriteLine(totalDistacne);
    }
}