using System;
using System.Collections.Generic;
public class Solution
{
    public int solution(int n, int k, int[] enemy)
    {
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();

        for (int i = 0; i < enemy.Length; i++)
        {
            int value = enemy[i];

            queue.Enqueue(value, -value); // 큰값부터 먼저 나오게 설정.

            // 병사가 부족하면 진행시점에서 무적권 사용해서 보충.
            while (n < value && queue.Count > 0 && k > 0)
            {
                int pop = queue.Dequeue();
                n += pop;
                k--;
            }

            if (n >= value)
            {
                n -= value;
            }
            else
                return i;
        }

        return enemy.Length;
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
}