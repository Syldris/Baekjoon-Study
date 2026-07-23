using System;
using System.Collections.Generic;
class Solution
{
    public int solution(int N, int[,] road, int K)
    {
        int answer = 0;

        List<(int node, int len)>[] graph = new List<(int node, int len)>[N + 1];
        for (int i = 1; i <= N; i++)
        {
            graph[i] = new List<(int node, int len)>();
        }

        for (int i = 0; i < road.GetLength(0); i++)
        {
            int from = road[i, 0];
            int to = road[i, 1];
            int cost = road[i, 2];

            graph[from].Add((to, cost));
            graph[to].Add((from, cost));
        }

        int[] visited = new int[N + 1];
        Array.Fill(visited, int.MaxValue);
        visited[1] = 0;

        Queue<(int node, int cost)> queue = new Queue<(int node, int cost)>();
        queue.Enqueue((1, 0));

        while (queue.Count > 0)
        {
            (int node, int cost) = queue.Dequeue();

            if (visited[node] > cost)
                continue;

            foreach (var next in graph[node])
            {
                int nextCost = cost + next.len;
                if (visited[next.node] > nextCost && nextCost <= K)
                {
                    visited[next.node] = nextCost;
                    queue.Enqueue((next.node, nextCost));
                }
            }
        }

        for (int i = 1; i <= N; i++)
        {
            if (visited[i] <= K)
                answer++;
        }


        return answer;
    }
}