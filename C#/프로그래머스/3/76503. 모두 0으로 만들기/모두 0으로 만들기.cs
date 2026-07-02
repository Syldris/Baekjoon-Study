using System;
using System.Collections.Generic;
public class Solution
{
    long answer = 0;
    List<int>[] graph;
    bool[] visited;
    long[] value;

    public long solution(int[] a, int[,] edges)
    {
        int n = a.Length;

        graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        visited = new bool[n];
        value = new long[n];

        for (int i = 0; i < n; i++)
        {
            value[i] = a[i]; // 값 이동과정에서 int 초과. long 자료형으로 이동.
        }

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int from = edges[i, 0];
            int to = edges[i, 1];

            graph[from].Add(to);
            graph[to].Add(from);
        }

        visited[0] = true;
        DFS(0, -1, value);

        return value[0] == 0 ? answer : -1;
    }

    void DFS(int num, int parent, long[] value)
    {
        foreach (var next in graph[num])
        {
            if (!visited[next])
            {
                visited[next] = true;
                DFS(next, num, value);
            }
        }

        if (parent != -1)
        {
            value[parent] += value[num]; // 자식 => 부모로 이동 (자식 양수3이면 -3후 부모+3), (음수-3이면 +3 부모에 -3)이므로 자식=> 부모로 이동.
            answer += Math.Abs(value[num]); // 이동횟수 증가.

            value[num] = 0;
        }
    }
}