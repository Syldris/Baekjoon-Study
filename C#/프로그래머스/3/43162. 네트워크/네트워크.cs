using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int n, int[,] computers)
    {
        int answer = 0;

        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue; // 같은 컴퓨터끼리 연결할 필요X.

                bool connected = computers[i, j] == 1;
                if (connected)
                {
                    graph[i].Add(j); // 양방향 연결.
                    graph[j].Add(i);
                }
            }
        }

        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (!visited[i]) // 방문한적 없다면 방문.
            {
                answer++;
                queue.Enqueue(i);
                visited[i] = true;

                while (queue.Count > 0) // i번 노드와 연결된 모든 컴퓨터를 방문처리.
                {
                    int node= queue.Dequeue();
                    foreach (var next in graph[node])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }
                }
            }
        }

        return answer; // 연결요소 갯수 반환.
    }
}