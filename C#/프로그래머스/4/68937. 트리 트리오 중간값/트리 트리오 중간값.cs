using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    List<int>[] graph;

    public int solution(int n, int[,] edges)
    {
        int answer = 0;

        graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int from = edges[i, 0];
            int to = edges[i, 1];

            // 양방향 연결
            graph[from].Add(to);
            graph[to].Add(from);
        }

        // DFS로 트리의 지름을 구하자. (양 끝점.)

        int[] distA = new int[n + 1]; // 일단 A를 찾기위해 임시로 사용.
        DFS(1, -1, distA); 
        int pointA = MaxDistPoint(distA); // 아무점에서 가장 긴 지점이 트리의 지름중 하나.

        Array.Clear(distA); // 1에서 구한 거리였으니 초기화하고 A로 다시 기록.

        DFS(pointA, -1, distA); 
        int pointC = MaxDistPoint(distA); // 트리의 지름 점에서 가장 먼 지점이 또 다른 트리의 지름 점.

        int[] distC = new int[n + 1];
        DFS(pointC, -1, distC); // C에서 모든점과의 거리를 구함.

        // (a,b) (b,c) (a,c) 거리중 중간값을 최대로 만들자.
        // a, c 점을 트리의 지름 양 끝점으로 두고 생각하면 3개점중 제일 크다. (a,c) >= (a,b), (b,c)

        // (a,c) 가 제일크고 Max((a,b), (b,c)) 가 2번째이므로 중간값.
        // a->b, c->b 양쪽 a,c 점에서의 b 거리를 구해서 Max(a->b, c->b) 인 b점이
        // 중간값을 최대로 할수있다.

        for (int i = 1; i <= n; i++)
        {
            int aTob = i != pointC ? distA[i] : 0; // b점 != c점 서로다른점이니 c점에선 a->b를 못구한다. 0으로처리. 
            int cTob = i != pointA ? distC[i] : 0; // 마찬가지로 c -> a점에서도 a는b가 아니니 0으로 예외처리.

            answer = Max(answer, Max(aTob, cTob));
        }

        return answer;
    }


    void DFS(int node, int parent, int[] dist)
    {
        foreach (var child in graph[node])
        {
            if (parent == child) continue;

            dist[child] = dist[node] + 1; // 거리 기록.
            DFS(child, node, dist);
        }
    }

    int MaxDistPoint(int[] dist) // 최대 거리 지점 반환함수.
    {
        int point = -1;
        int maxdist = 0;

        for (int i = 1; i < dist.Length; i++)
        {
            if (dist[i] > maxdist)
            {
                point = i;
                maxdist = dist[i];
            }
        }

        return point;
    }
}