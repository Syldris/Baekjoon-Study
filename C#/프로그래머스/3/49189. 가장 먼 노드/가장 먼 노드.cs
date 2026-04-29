using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int n, int[,] edge)
    {
        int answer = 0;

        List<int>[] graph = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < edge.GetLength(0); i++)
        {
            int a = edge[i, 0];
            int b = edge[i, 1];

            graph[a].Add(b);
            graph[b].Add(a);
        }


        int[] visited = new int[n + 1];
        Array.Fill(visited, int.MaxValue);
        visited[1] = 0;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            foreach (var next in graph[node])
            {
                if (visited[node] + 1 < visited[next])
                {
                    visited[next] = visited[node] + 1;
                    queue.Enqueue(next);
                }
            }
        }

        int max = 0;
        for (int i = 1; i <= n; i++)
        {
            if (visited[i] > max)
            {
                max = visited[i];
                answer = 1;
            }
            else if (visited[i] == max)
            {
                answer++;
            }
        }

        return answer;
    }
}