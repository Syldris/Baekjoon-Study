using System;
using System.Collections.Generic;
public struct Node
{
    public bool complete; // 조건 만족
    public int childIndex; // 가르키는 자식 인덱스

    public int min; // 노드에서 가능한 최소, 최대 숫자.
    public int max;
}

public class Solution
{
    Node[] nodes;
    int reafNode = 0;
    int completeReafNode = 0; // 조건 만족한 리프노드 갯수.
    List<int> route = new List<int>(); // 리프노드 방문 경로

    public int[] solution(int[,] edges, int[] target)
    {
        int n = target.Length;

        List<int>[] tree = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            tree[i] = new List<int>();

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int parent = edges[i, 0];
            int child = edges[i, 1];

            tree[parent].Add(child);
        }

        for (int i = 1; i <= n; i++) // 가장 작은 간선부터 가르키게 정렬.
        {
            if (tree[i].Count > 0)
                tree[i].Sort();
            else
                reafNode++; // 리프노드 갯수도 미리 세기.
        }

        nodes = new Node[n + 1];

        for (int i = 1; i <= n; i++)
        {
            // 리프노드이며, Count가 0이면 이미 완성.
            if (tree[i].Count == 0 && target[i - 1] == 0)
            {
                nodes[i].complete = true;
                completeReafNode++;
            }
        }

        while (completeReafNode != reafNode) // 모든 리프노드 조건만족할때까지 DFS로 탐색
        {
            DFS(1, target, tree);
        }

        for (int i = 1; i <= n; i++)
        {
            if (nodes[i].min > target[i - 1]) // |최소값 > 조건값| 범위밖이면 달성불가.
                return new int[] { -1 };
        }

        int[] answer = new int[route.Count];

        for (int i = 0; i < route.Count; i++)
        {
            int node = route[i];
            for (int k = 1; k <= 3; k++) // 오름차순이여야 하니 1부터.
            {
                int min = nodes[node].min - 1;
                int max = nodes[node].max - 3;

                // k만큼 제거했을때에도 min~max사이를 유지하게끔.
                if (min <= target[node - 1] - k && target[node - 1] - k <= max)
                {
                    // k만큼 제거하고 범위도 처리.
                    target[node - 1] -= k;
                    nodes[node].min -= 1;
                    nodes[node].max -= 3;

                    answer[i] = k;
                    break;
                }
            }
        }

        return answer;
    }

    void DFS(int num, int[] target, List<int>[] tree)
    {
        // 리프노드일때 처리.
        if (tree[num].Count == 0)
        {
            // 숫자카드 최소 1, 최대 3.
            nodes[num].min++;
            nodes[num].max += 3;

            // max가 조건이상이면 만족.
            if (!nodes[num].complete && nodes[num].max >= target[num - 1])
            {
                nodes[num].complete = true;
                completeReafNode++;
            }

            route.Add(num);
            return;
        }

        int child = nodes[num].childIndex;

        nodes[num].childIndex = (nodes[num].childIndex + 1) % tree[num].Count; // 접근마다 다음 자식노드를 가르키게끔.

        DFS(tree[num][child], target, tree);
    }
}