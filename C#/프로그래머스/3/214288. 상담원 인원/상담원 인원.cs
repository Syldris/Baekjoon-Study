using System;
using System.Collections.Generic;
using static System.Math;
public class Solution
{
    int answer = int.MaxValue;

    int k = 0;
    int n = 0;

    public int solution(int k, int n, int[,] reqs)
    {
        this.k = k;
        this.n = n;

        int[] arr = new int[k + 1];

        DFS(1, n, arr, reqs);

        return answer;
    }

    // 타입, 남은 인원
    void DFS(int type, int people, int[] arr, int[,] reqs)
    {
        if (type == k + 1)
        {
            int value = 0;
            PriorityQueue<int, int>[] agent = new PriorityQueue<int, int>[k + 1];

            for (int i = 1; i <= k; i++)
            {
                agent[i] = new PriorityQueue<int, int>();
                for (int j = 1; j <= arr[i]; j++)
                {
                    agent[i].Enqueue(0, 0); // type별 상담사 배치. 
                }
            }

            for (int i = 0; i < reqs.GetLength(0); i++)
            {
                int a = reqs[i, 0]; // 상담 요청 시각.
                int b = reqs[i, 1]; // 상담 시간.
                int c = reqs[i, 2]; // 상담 타입.

                int lastTime = agent[c].Dequeue(); // 제일 빨리 나온 상담사

                if (lastTime > a)
                {
                    value += lastTime - a; // 대기 시간 추가.
                    a = lastTime; // 상담 시작시간이 미뤄짐.
                }

                agent[c].Enqueue(a + b, a + b); // 상담시작. 끝나는 시각에 비워두게 배정.

            }

            answer = Min(value, answer);

            return;
        }

        int sideSize = k - type; // 뒤에 남은 유형에도 최소 1명 배치 필요하므로 k-현재타입으로 남은 타입에 1명이상을 보장.

        for (int i = 1; i <= people - sideSize; i++) // 모든유형은 최소 한명의 상담사 배치.
        {
            arr[type] = i;
            DFS(type + 1, people - i, arr, reqs);
        }
    }

}

// <원소,우선순위> 우선순위에 오는 자료형 비교기능이 필요.
// 이진힙 구현. 부모 <=> 자식 관계에서 우선순위 부모 < 자식을 유지.
// 최선 우선순위(루트)을 O(1)에 꺼내고 우선순위 재정리에 이진힙 높이(logN) 만큼 소요. 
public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    List<(TElement, TPriority)> _heap = new List<(TElement, TPriority)>();
    public int count => _heap.Count;

    // 삽입. 원소 끝자리에 넣고 부모과 반복비교로 부모가 작게끔 유지.
    public void Enqueue(TElement element, TPriority priority)
    {
        _heap.Add((element, priority));

        int index = count - 1;

        while (index > 0) // 자식 => 부모 방향으로 (부모가 더 작게끔)갱신
        {
            int ParentIndex = (index - 1) / 2;
            if (_heap[index].Item2.CompareTo(_heap[ParentIndex].Item2) >= 0) // 자식 - 부모 >= 0 이라면, 자식 >= 부모 이므로 부모가 더 작으니 스탑.
            {
                break;
            }

            Swap(index, ParentIndex);
            index = ParentIndex;
        }
    }

    public TElement Dequeue()
    {
        TElement output = _heap[0].Item1;

        Swap(0, count - 1); // 루트와 힙의 끝을 스왑.
        _heap.RemoveAt(count - 1);

        int index = 0; // 루트 힙으로 가져온걸 제자리로 찾아오면서 원위치.

        while (index < count) // 힙 범위 안에서 부모 => 자식 방향으로 갱신.
        {
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;

            int swapIndex = -1;

            if (leftIndex >= count && rightIndex >= count) // 둘다 범위밖.
                break;

            // 한쪽이 범위 밖일때.
            if (leftIndex >= count) swapIndex = rightIndex;
            else if (rightIndex >= count) swapIndex = leftIndex;

            else if (_heap[leftIndex].Item2.CompareTo(_heap[rightIndex].Item2) >= 0) // 왼쪽 오른쪽 비교
                swapIndex = rightIndex; // 오른쪽이 더작음.
            else
                swapIndex = leftIndex;

            // 자식 - 부모 >= 0 이면 자식 >= 부모이므로 스탑.
            if (_heap[swapIndex].Item2.CompareTo(_heap[index].Item2) >= 0)
                break;

            Swap(index, swapIndex);

            index = swapIndex;
        }

        return output;
    }

    void Swap(int index1, int index2) // 원소 스왑.
    {
        var temp = _heap[index1];
        _heap[index1] = _heap[index2];
        _heap[index2] = temp;
    }
}