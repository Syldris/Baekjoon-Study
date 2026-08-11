using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    public int solution(int n, int[,] lighthouse)
    {
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < lighthouse.GetLength(0); i++)
        {
            int from = lighthouse[i, 0];
            int to = lighthouse[i, 1];

            graph[from].Add(to);
            graph[to].Add(from);
        }


        int[,] tree = new int[n + 1, 2]; // treeDP.
                                         // [node,0] = 이 노드가 불꺼져있을때의 최소갯수. 
                                         // [node,1] = 이 노드가 불켜져있을때의 최소갯수.

        DFS(1, -1, tree, graph);

        // 1번노드가 꺼져있을때 최소갯수 vs 켜져있을때 최소갯수중 작은걸 반환.
        return Min(tree[1, 0], tree[1, 1]);
    }

    void DFS(int node, int parent, int[,] tree, List<int>[] graph)
    {
        tree[node, 0] = 0; // 이 노드 꺼져있음.
        tree[node, 1] = 1; // node 본인이 켜져있으므로 1로 시작.

        foreach (var child in graph[node])
        {
            if (child == parent) continue; // 트리 구조니까 자식 => 부모 연결만 끊어두면 모든 노드를 1번만 탐색.

            DFS(child, node, tree, graph);

            tree[node, 0] += tree[child, 1]; // 본인이 꺼져있을땐 적어도 본인 자식은 켜져있어야 "인접노드중 노드가 켜져야함" 을 만족함.
            tree[node, 1] += Min(tree[child, 0], tree[child, 1]); // 본인이 켜져있을땐 자식이 ON/OFF와 상관없으므로 최적값 선택.
        }
    }
}