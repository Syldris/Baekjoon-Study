using System;
using System.Collections.Generic;

public class Solution
{
    public int solution(int n, int[,] costs)
    {
        int answer = 0;

        List<(int node, int cost)>[] graph = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < costs.GetLength(0); i++)
        {
            int from = costs[i, 0];
            int to = costs[i, 1];
            int cost = costs[i, 2];

            graph[from].Add((to, cost));
            graph[to].Add((from, cost));
        }

        bool[] visited = new bool[n];

        PriorityQueue<(int node, int cost), int> queue = new PriorityQueue<(int node, int cost), int>();

        // 어디에서 시작해도 상관없음. (양방향길 + 항상 연결가능)
        queue.Enqueue((0, 0), 0);

        // MST 최소신장트리로 섬 모두를 연결하는 최소비용을 구하자.
        while (queue.Count > 0)
        {
            (int node, int cost) = queue.Dequeue();

            if (visited[node]) continue;

            visited[node] = true;
            answer += cost; // 방문할떄 연결 확정짓고 비용 추가.

            foreach (var next in graph[node])
            {
                if (!visited[next.node])
                {
                    queue.Enqueue((next.node, next.cost), next.cost);
                }
            }
        }

        return answer;
    }
}

// 부모 <= 자식을 유지하면서 이진힙을 만들기.
public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    List<(TElement, TPriority)> _heap = new List<(TElement, TPriority)>();
    public int Count => _heap.Count;

    public void Enqueue(TElement element, TPriority priority)
    {
        _heap.Add((element, priority));
        int index = Count - 1;

        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (_heap[parentIndex].Item2.CompareTo(_heap[index].Item2) <= 0) // 부모 <= 자식 이면 이진힙 만족했으니 끝.
                break;

            Swap(index, parentIndex);

            index = parentIndex;
        }
    }

    public TElement Dequeue()
    {
        TElement output = _heap[0].Item1;
        Swap(0, Count - 1); // 끝자리랑 바꾸기
        _heap.RemoveAt(Count - 1); // 빈공간없이 깔끔하게 제거.

        int index = 0;
        while (index < Count)
        {
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;

            int swapIndex = -1;

            if (leftIndex >= Count) // 왼쪽 벗어나면 자동으로 오른쪽도 범위밖.
                break;

            if (rightIndex >= Count) // 오른쪽만 범위밖이면 왼쪽 선택.
                swapIndex = leftIndex;

            else if (_heap[leftIndex].Item2.CompareTo(_heap[rightIndex].Item2) >= 0) // 왼쪽 - 오른쪽 >= 0 이면 오른쪽이 더작으니 선택. 
                swapIndex = rightIndex;
            else  // 반대의 경우는 오른쪽이니 더 크니 왼쪽 선택.
                swapIndex = leftIndex;

            if (_heap[index].Item2.CompareTo(_heap[swapIndex].Item2) <= 0) // 부모 - 자식 <= 0을 이면 자식이 더 크니 더이상 바꿀필요 X
                break;

            Swap(index, swapIndex);
            index = swapIndex;
        }


        return output;
    }

    void Swap(int index1, int index2)
    {
        var temp = _heap[index1];
        _heap[index1] = _heap[index2];
        _heap[index2] = temp;
    }
}