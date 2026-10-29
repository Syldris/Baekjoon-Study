using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    public int solution(int n, int start, int end, int[,] roads, int[] traps)
    {
        List<(int node, int cost, bool reversal)>[] graph = new List<(int, int, bool)>[n + 1];

        Dictionary<int, int> dict = new();
        for (int i = 0; i < traps.Length; i++)
        {
            dict.Add((traps[i]), i);
        }

        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < roads.GetLength(0); i++)
        {
            // P -> Q 단방향 S비용 길
            int p = roads[i, 0];
            int q = roads[i, 1];
            int s = roads[i, 2];

            graph[p].Add((q, s, false)); // 정방향
            graph[q].Add((p, s, true)); // 역방향 그래프
        }

        int[,] visited = new int[n + 1, 1 << traps.Length]; // 노드번호, 트랩방 방문정보 비트마스킹
        for (int i = 1; i <= n; i++)
            for (int j = 0; j < 1 << traps.Length; j++)
                visited[i, j] = int.MaxValue;

        PriorityQueue<(int node, int cost, int bit), int> queue = new();
        queue.Enqueue((start, 0, 0), 0);
        visited[start, 0] = 0;

        while (queue.Count > 0)
        {
            (int node, int cost, int bit) = queue.Dequeue();

            if (cost > visited[node, bit]) // 이미 먼저 싼비용으로 처리했으면 스킵.
                continue;

            if (node == end)
                return cost;

            foreach (var next in graph[node])
            {
                int nextCost = cost + next.cost;
                int nextBit = bit;

                bool fromTrap = dict.ContainsKey(node) && (bit & (1 << dict[node])) != 0;
                bool toTrap = dict.ContainsKey(next.node) && (bit & (1 << dict[next.node])) != 0;

                // 현재 or 도착 노드중 하나만 On이면 역방향. 둘다 On / off면 정방향.
                bool reversal = fromTrap ^ toTrap;

                if (reversal != next.reversal) continue; // 간선 방향이 다르면 스킵.

                if (dict.TryGetValue(next.node, out int order)) // 도착노드가 트랩노드.
                {
                    nextBit ^= 1 << order; // 트랩비트마스킹에 0 => 1, 1=>0 이렇게 반전 되게끔 기록.
                }

                if (visited[next.node, nextBit] > nextCost)
                {
                    visited[next.node, nextBit] = nextCost;
                    queue.Enqueue((next.node, nextCost, nextBit), nextCost);
                }
            }
        }

        return 0;
    }

    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        List<(TElement element, TPriority priority)> list = new();
        public int Count => list.Count;

        public void Enqueue(TElement element, TPriority priority)
        {
            list.Add((element, priority));

            int index = Count - 1;
            while (index > 0)
            {
                int swapIndex = (index - 1) / 2; // 부모

                if (list[swapIndex].priority.CompareTo(list[index].priority) <= 0) // 부모 <= 자식이면 스탑.
                    break;

                Swap(index, swapIndex);
                index = swapIndex;
            }
        }

        public TElement Dequeue()
        {
            var output = list[0];

            // 뽑은값 맨 마지막값과 스왑하고 삭제.
            Swap(0, Count - 1);
            list.RemoveAt(list.Count - 1);

            int index = 0;

            while (index < Count)
            {
                int swapIndex = -1; // 자식인덱스

                int leftIndex = index * 2 + 1;
                int rightIndex = index * 2 + 2;

                if (leftIndex >= Count) // 왼쪽 자식이 범위밖이면 오른쪽도 범위밖이니 스탑.
                    break;
                else if (rightIndex >= Count) // 오른쪽만 범위밖.
                    swapIndex = leftIndex;
                else
                {
                    if (list[leftIndex].priority.CompareTo(list[rightIndex].priority) <= 0) // 왼쪽 <= 오른쪽 일때 왼쪽 선택.
                        swapIndex = leftIndex;
                    else
                        swapIndex = rightIndex;
                }

                if (list[index].priority.CompareTo(list[swapIndex].priority) <= 0) // 부모 <= 자식이면 스탑.
                    break;

                Swap(index, swapIndex);
                index = swapIndex;
            }

            return output.element;
        }

        void Swap(int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}