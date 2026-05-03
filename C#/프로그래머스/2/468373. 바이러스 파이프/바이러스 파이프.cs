using System;
using System.Collections.Generic;
public class Solution
{
    int n = 0;
    int k = 0;
    int value = 0;
    int answer = 0;

    List<(int node, int type)>[] graph;
    bool[] infectionNode;

    Queue<int> queue = new Queue<int>();

    // 프로그래머스가 함수안에 함수가 지원이 안되는거 같다..
    // 함수안에서 초기화만 해주고 클래스내 필드로 사용

    public int solution(int n, int infection, int[,] edges, int k)
    {
        this.k = k;
        this.n = n;

        this.graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int x = edges[i, 0];
            int y = edges[i, 1];
            int type = edges[i, 2];

            graph[x].Add((y, type));
            graph[y].Add((x, type));
        }

        infectionNode = new bool[n + 1];

        // 시작 노드는 감염되어있음.
        infectionNode[infection] = true;
        value = 1;

        for (int i = 1; i <= 3; i++)
        {
            BackTrack(1, i);
        }

        return answer;
    }

    void BackTrack(int depth, int type)
    {
        if (depth > k)
        {
            answer = Math.Max(answer, value);
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            if (infectionNode[i])
                queue.Enqueue(i);
        }

        // 이번 단계에서 감염되는 노드를 모음.
        List<int> nodes = new List<int>();

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var next in graph[node])
            {
                // 타입 같을때만 파이프가 열림.
                if (next.type != type) continue;

                if (!infectionNode[next.node])
                {
                    infectionNode[next.node] = true;
                    value++; // 감염

                    queue.Enqueue(next.node);
                    nodes.Add(next.node);
                }
            }
        }

        for (int i = 1; i <= 3; i++)
        {
            BackTrack(depth + 1, i);
        }

        // 백트래킹 회수. 이전 단계로 되돌아 가기 위해 이번단계노드 감염 취소.
        foreach (var item in nodes)
        {
            infectionNode[item] = false;
            value--;
        }
    }
}
