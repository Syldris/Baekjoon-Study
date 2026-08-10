using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(int n, int[,] roads, int[] sources, int destination)
    {
        int[] answer = new int[sources.Length];

        List<int>[] graph = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < roads.GetLength(0); i++)
        {
            int from = roads[i, 0];
            int to = roads[i, 1];

            graph[from].Add(to); // 양방향 길
            graph[to].Add(from);
        }

        int[] visited = new int[n + 1];
        Array.Fill(visited, int.MaxValue);

        // 모든지역에서 시작지점의 거리 = 시작지점에서 모든지역의 거리 로 구할수있음.
        // 고로 시작지점에서 다익1번으로 가능.

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(destination); 
        visited[destination] = 0;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            foreach (var next in graph[node])
            {
                if (visited[node] + 1 < visited[next])
                {
                    queue.Enqueue(next);
                    visited[next] = visited[node] + 1;
                }
            }
        }

        for (int i = 0; i < sources.Length; i++)
        {
            int pos = sources[i];
            answer[i] = visited[pos] == int.MaxValue ? -1 : visited[pos]; // 도착불가능 지역이면 -1
        }

        return answer;
    }
}