using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
public class NewEmptyCSharpScript
{
    static List<int>[] graph;
    static bool[] visited;

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        graph = new List<int>[n+1];
        visited = new bool[n+1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }
        for (int i = 0; i < m; i++)
        {
            string[] text = Console.ReadLine().Split();
            int u = int.Parse(text[0]);
            int v = int.Parse(text[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }
        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            if (!visited[i])
            {
                DFS(i);
                count++;
            }
        }

        Console.Write(count);
    }

    static void DFS(int node)
    {
        visited[node] = true;
        foreach (var item in graph[node])
        {
            if (!visited[item])
            {
                DFS(item);
            }
        }
    }
}
