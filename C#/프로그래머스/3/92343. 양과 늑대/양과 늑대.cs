using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[] info, int[,] edges)
    {
        int answer = 0;
        int n = info.Length;

        // form => to 방식으로 검색하기 위해서 그래프 형태로 저장
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int from = edges[i, 0];
            int to = edges[i, 1];

            // 양방향 길
            graph[from].Add(to);
            graph[to].Add(from);
        }

        // 같은 노드여도 양이 몇마리 인지, 늑대가 몇마리인지에 따라 상황이 다르며
        // 추가로 어디에서 얻었는지 기록하기 위해 비트마스킹 쓰자.
        // 1<<n 으로 기록해서 n번 방문 노드를 1로 기록. 0,1,3번 노드 방문이면 1011 이런식으로 기록.

        HashSet<int>[] visited = new HashSet<int>[n];
        for (int i = 0; i < n; i++)
            visited[i] = new HashSet<int>();


        Queue<(int node, int sheep, int wolf, int bit)> queue = new Queue<(int node, int sheep, int wolf, int bit)>();
        queue.Enqueue((0, 1, 0, 1)); // 0번노드 양시작 고정임

        while (queue.Count > 0)
        {
            (int node, int sheep, int wolf, int bit) = queue.Dequeue();

            if (sheep > answer) // 최대 양 몇마리인지 기록.
                answer = sheep;

            foreach (var nextNode in graph[node])
            {
                int cursheep = sheep;
                int curwolf = wolf;

                if (((bit >> nextNode) & 1) != 1) // bit로 해당 노드 방문했는지 확인 (bit & (1<<n)) == 1 << n 으로 밀어도 될듯. 
                {
                    // 처음 방문하는 도착 노드만 얻음. 노드정보 따라 양 or 늑대 획득
                    if (info[nextNode] == 0)
                        cursheep++;
                    else
                        curwolf++;

                    if (curwolf >= cursheep) // 늑대마릿수가 양마릿수 이상이라면 불가.
                        continue;
                }
                int curBit = bit | 1 << nextNode; // nextNode위치 1로 기록.

                if (!visited[nextNode].Contains(curBit))
                {
                    visited[nextNode].Add(curBit); // 중복방문 방지.
                    queue.Enqueue((nextNode, cursheep, curwolf, curBit));
                }
            }

        }

        return answer;
        // 풀고 생각난건데 그래프 형태 대신에 이진트리이니 단방향으로 탐색하면서 갈수있는 다음노드를 비트마스킹형태로 저장하는게 더 효율적일듯.
    }
}
