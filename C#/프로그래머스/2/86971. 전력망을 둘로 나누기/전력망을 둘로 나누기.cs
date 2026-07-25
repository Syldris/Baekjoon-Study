using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int n, int[,] wires)
    {
        int answer = int.MaxValue;

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();


        for (int i = 0; i < n - 1; i++)
        {
            int u = wires[i, 0];
            int v = wires[i, 1];

            graph[u].Add(v);
            graph[v].Add(u);
        }


        bool[] visited = new bool[n + 1];
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < n - 1; i++)
        {
            int v1 = wires[i, 0];
            int v2 = wires[i, 1];

            int value = 0;

            visited[1] = true;
            queue.Enqueue(1); // 트리니까 어디서 시작해도 상관없음.

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                value++;

                foreach (var next in graph[node])
                {
                    if (visited[next]) continue;

                    // v1, v2를 오가는 전력망을 끊었음.
                    if ((node == v1 && next == v2) || (node == v2 && next == v1)) continue;

                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
            Array.Fill(visited, false);

            answer = Math.Min(answer, Math.Abs(value - (n - value))); // N개 노드중 value갯수의 네트워크와 N-value개의 네트워크 개수의 차이 비교.  
        }

        return answer;
    }
}