using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int[,] jobs)
    {
        int answer = 0;

        int n = jobs.GetLength(0);

        // 시작시간, 걸리는시간, 작업 번호
        List<(int startTime, int time, int number)> info = new List<(int startTime, int time, int number)>();

        for (int i = 0; i < n; i++)
        {
            int startTime = jobs[i, 0];
            int time = jobs[i, 1];

            info.Add((startTime, time, i));
        }

        // 시작시간, 걸리는시간, 작업번호 기준으로 정렬.
        info.Sort();

        int curTime = info[0].startTime; // 현재 시간
        int lastIndex = 0; // 지금까지 읽은 작업 인덱스

        PriorityQueue<(int startTime, int time), (int time, int startTime, int number)> queue = new PriorityQueue<(int startTime, int time), (int time, int startTime, int number)>();

        // 정렬때문에 시작시간이 같으면 우선순위 높은작업이 먼저옴
        queue.Enqueue((info[0].startTime, info[0].time), (info[0].time, info[0].startTime, info[0].number));

        while (queue.Count > 0)
        {
            (int startTime, int time) = queue.Dequeue();

            if(curTime < startTime) // 현재시간이 시작시간 전이면 좀 기다림.
                curTime = startTime;

            curTime += time;

            answer += curTime - startTime;

            for (int i = lastIndex + 1; i < n; i++)
            {
                if (info[i].startTime <= curTime || queue.Count == 0) // 현재시각이 신청시각이상이라면 후보로 넣기. 0이면 기다려서라도 넣음.
                {
                    queue.Enqueue((info[i].startTime, info[i].time), (info[i].time, info[i].startTime, info[i].number));
                    lastIndex = i;
                }
                else
                    break;
            }
        }

        return answer / n;
    }
}
public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    List<(TElement, TPriority)> _heap = new List<(TElement, TPriority)>();
    public int Count => _heap.Count;

    public void Enqueue(TElement element, TPriority priority)
    {
        _heap.Add((element, priority));

        int index = _heap.Count - 1;

        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (_heap[parentIndex].Item2.CompareTo(_heap[index].Item2) <= 0) // 부모 <= 자식 이면 멈춰도 됨
                break;

            Swap(index, parentIndex);

            index = parentIndex;
        }
    }

    public TElement Dequeue()
    {
        TElement output = _heap[0].Item1;

        Swap(0, Count - 1);
        _heap.RemoveAt(Count - 1);

        int index = 0;

        while (index < Count)
        {
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;

            int swapIndex = 0;

            if (leftIndex >= Count) // 왼쪽이 범위밖이면 오른쪽도 범위밖
                break;

            if (rightIndex >= Count) // 오른쪽만 범위밖이면 왼쪽 고정
                swapIndex = leftIndex;

            else if (_heap[leftIndex].Item2.CompareTo(_heap[rightIndex].Item2) >= 0) // 왼쪽 - 오른쪽 >= 0 이면 왼쪽이 더크니 오른쪽 선택.
                swapIndex = rightIndex;
            else
                swapIndex = leftIndex;

            if (_heap[swapIndex].Item2.CompareTo(_heap[index].Item2) >= 0) // 자식 >= 부모 
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