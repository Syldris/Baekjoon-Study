using System;
using System.Collections.Generic;
using static System.Math;

public class Solution
{
    enum Area
    {
        Gate,
        RestArea,
        MountainPeek
    }

    public int[] solution(int n, int[,] paths, int[] gates, int[] summits)
    {
        int[] answer = new int[2] { int.MaxValue, int.MaxValue };

        List<(int node, int cost)>[] graph = new List<(int node, int cost)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int node, int cost)>();

        for (int i = 0; i < paths.GetLength(0); i++)
        {
            int from = paths[i, 0];
            int to = paths[i, 1];
            int cost = paths[i, 2];

            graph[from].Add((to, cost)); // 양방향 길
            graph[to].Add((from, cost));
        }

        Area[] area = new Area[n + 1]; // 지역 정보
        Array.Fill(area, Area.RestArea); // 기본적으로 빈공간은 휴식터

        for (int i = 0; i < gates.Length; i++)
            area[gates[i]] = Area.Gate;

        for (int i = 0; i < summits.Length; i++)
            area[summits[i]] = Area.MountainPeek;

        long[,] visited = new long[n + 1, 2]; //[지역,산봉우리 방문여부] = 최솟값.
        for (int i = 1; i <= n; i++)
            for (int j = 0; j < 2; j++)
                visited[i, j] = long.MaxValue;

        // 원소 (노드, 비용, 산봉우리 방문지점), 우선순위(적은 비용, 가장 낮은 산봉우리번호순)
        PriorityQueue<(int node, int cost, int peekVisited), (int cost, int peekNumber)> queue = new PriorityQueue<(int node, int cost, int peekVisited), (int cost, int peekNumber)>();

        for (int i = 0; i < gates.Length; i++) // 출입구 한번에 다넣고 멀티소스 다익.
        {
            queue.Enqueue((gates[i], 0, -1), (0, -1));
            visited[gates[i], 0] = 0;
        }

        while (queue.Count > 0)
        {
            (int node, int cost, int peekVisited) = queue.Dequeue();

            if (peekVisited != -1 && area[node] == Area.Gate) // 산봉우리 방문하고 출입구로 왔으면 끝.
            {
                // 우선순위로 코스트 뒤에 산봉우리 번호도 포함했기에
                // 코스트가 가장적은코스 + 산봉우리번호도 가장 낮은 코스가 제일 먼저 큐로 온다.

                answer[0] = peekVisited;
                answer[1] = cost;
                return answer;
            }

            foreach (var next in graph[node])
            {
                int nextCost = Max(cost, next.cost); // 현재까지 걸어온 길중 Max값.

                int peek = peekVisited;

                if (area[next.node] == Area.MountainPeek) // 다음 방문지점이 산봉우리.
                {
                    if (peek != -1) continue; // 이미 산봉우리를 방문했으면 다른 산봉우리 방문못함.

                    peek = next.node; // 미방문 상태면 산봉우리 번호 기록.
                }

                int peekIndex = peek == -1 ? 0 : 1; // 산봉우리 방문여부.

                if (nextCost < visited[next.node, peekIndex])
                {
                    queue.Enqueue((next.node, nextCost, peek), (nextCost, peek));
                    visited[next.node, peekIndex] = nextCost;
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