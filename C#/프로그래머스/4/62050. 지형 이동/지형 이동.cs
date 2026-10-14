using System;
using System.Collections.Generic;
public class Solution
{
    int n;
    int[] dx = { -1, 1, 0, 0 };
    int[] dy = { 0, 0, -1, 1 };

    int[,] group;
    bool[,] visited;
    public int solution(int[,] land, int height)
    {
        // 높이 차 height 이하의 상하좌우 인접칸은 서로 방문가능.
        // 사다리 없이 방문할수있는 지역을 묶어서 그룹으로 만들자.
        // 그룹끼리 서로 방문하려면 무조건 사다리가 필요한데,
        // 비용이 제일 적은 사다리부터 깔아서 방문하면 항상 최적일것이다. 

        int answer = 0;

        n = land.GetLength(0);

        group = new int[n, n];
        visited = new bool[n, n];

        int groupNumber = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (!visited[c, r])
                {
                    BFS(c, r, height, groupNumber, land);
                    groupNumber++; // 그룹마다 번호 다르게.
                }
            }
        }

        Array.Clear(visited);

        PriorityQueue<(int x, int y, int cost), int> queue = new();
        queue.Enqueue((0, 0, 0), 0);

        bool[] merge = new bool[groupNumber];
        int mergeSize = 0;

        while (queue.Count > 0)
        {
            (int x, int y, int cost) = queue.Dequeue();

            if (visited[x, y]) continue;
            visited[x, y] = true;

            if (!merge[group[x, y]]) // 미 병합된 상태라면 비용내고 병합완료.
            {
                answer += cost;
                merge[group[x, y]] = true;
                mergeSize++;
            }

            if (mergeSize == groupNumber) break; // 모두 병합되면 종료.

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= n || py >= n)
                    continue;

                int moveCost = 0;

                if (group[x, y] != group[px, py]) // 그룹이 서로 다를때.
                {
                    if (merge[group[px, py]]) continue; // 이미 합병된 그룹이면 비용주고 갈필요 X.

                    moveCost = Math.Abs(land[x, y] - land[px, py]);
                }

                if (!visited[px, py])
                {
                    queue.Enqueue((px, py, moveCost), moveCost); // 항상 작은 비용부터 먼저.
                }
            }
        }

        return answer;
    }

    void BFS(int c, int r, int height, int groupNumber, int[,] land)
    {
        Queue<(int x, int y)> queue = new();

        queue.Enqueue((c, r));
        visited[c, r] = true;
        group[c, r] = groupNumber;

        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= n || py >= n) continue;

                // 미방문 + 높이차 height 이하일때 방문.
                if (!visited[px, py] && Math.Abs(land[x, y] - land[px, py]) <= height)
                {
                    visited[px, py] = true;
                    group[px, py] = groupNumber;
                    queue.Enqueue((px, py));
                }
            }
        }
    }
}

public class PriorityQueue<TElemant, Tpriority> where Tpriority : IComparable<Tpriority>
{
    // 이진 힙. 이진트리에서 부모 <= 자식 을 유지하자.

    List<(TElemant elemant, Tpriority priority)> list = new List<(TElemant, Tpriority)>();
    public int Count => list.Count;

    // 원소 삽입후 부모가 더 작을때까지 계속 올리자.
    public void Enqueue(TElemant elemant, Tpriority priority)
    {
        list.Add((elemant, priority));
        int index = list.Count - 1;

        while (index > 0) // 최상단까지
        {
            int parentIndex = (index - 1) / 2;

            if (list[parentIndex].priority.CompareTo(list[index].priority) <= 0) // 부모 <= 자식이면 스탑.
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    // 최우선순위 0번값 뽑고, 0 <-> 마지막 스왑후 끝부분 삭제. 마지막원소가 0번에서 내려오면서 원위치.
    public TElemant Dequeue()
    {
        TElemant pop = list[0].elemant;
        Swap(0, Count - 1);
        list.RemoveAt(Count - 1);

        int index = 0;

        while (index < Count - 1)
        {
            int swapIndex = -1;

            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;

            if (leftChildIndex >= Count) // 왼쪽 인덱스가 범위밖이라면 오른쪽도 범위밖이니 바로 종료.
                break;
            else if (rightChildIndex >= Count) // 오른쪽만 범위밖이면 자동으로 왼쪽 선택.
                swapIndex = leftChildIndex;
            else
            {
                if (list[leftChildIndex].priority.CompareTo(list[rightChildIndex].priority) > 0) // 왼쪽 > 오른쪽 이라면 작은 오른쪽을 선택
                    swapIndex = rightChildIndex;
                else
                    swapIndex = leftChildIndex;
            }

            if (list[index].priority.CompareTo(list[swapIndex].priority) <= 0) // 부모 <= 자식 이면 스탑.
                break;

            Swap(index, swapIndex);
            index = swapIndex;
        }

        return pop;
    }


    void Swap(int index1, int index2)
    {
        var temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}