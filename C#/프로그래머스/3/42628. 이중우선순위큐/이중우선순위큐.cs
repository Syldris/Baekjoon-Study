using System;
using System.Collections.Generic;
public class Solution
{
    public int[] solution(string[] operations)
    {
        int[] answer = new int[2];

        Dictionary<int, int> dict = new Dictionary<int, int>(); // 숫자, 갯수 쌍으로 저장
        int n = operations.Length;

        List<(int x, int y)> list = new List<(int x, int y)>();

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        for (int i = 0; i < n; i++)
        {
            string[] split = operations[i].Split();

            if (split[0] == "I")
            {
                int num = int.Parse(split[1]);
                minHeap.Enqueue(num, num);
                maxHeap.Enqueue(num, -num); // 큰수부터 나오게 부호반전.

                if (dict.TryGetValue(num, out int value))
                {
                    dict[num] = value + 1;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            else
            {
                if (split[1] == "1")
                {
                    while (maxHeap.GetCount() > 0)
                    {
                        int value = maxHeap.Dequeue();

                        if (dict[value] > 0) // 정보를 저장하는 딕셔너리에 value가 실제로 1개이상 있을때만 뺄수있음.
                        {
                            dict[value]--;
                            break;
                        }
                    }
                }
                else
                {
                    while (minHeap.GetCount() > 0)
                    {
                        int value = minHeap.Dequeue();

                        if (dict[value] > 0)
                        {
                            dict[value]--;
                            break;
                        }
                    }
                }
            }
        }

        while (maxHeap.GetCount() > 0)
        {
            int value = maxHeap.Dequeue();
            if (dict[value] > 0)  // value가 1개이상 남아있으면 최댓값 기록후 종료. 
            {

                answer[0] = value;
                break;
            }
        }

        while (minHeap.GetCount() > 0)
        {
            int value = minHeap.Dequeue();
            if (dict[value] > 0) // value가1개이상 남아있으면 최솟값 기록후 종료. 
            {
                answer[1] = value;
                break;
            }
        }

        return answer;
    }

    // 프로그래머스 컴파일러가 PQ가 없다..
    // 부모-자식 관계에서 부모가 자식보다 작다. 
    // 이 특성만을 유지하면 이진트리 힙을 구현 할 수있다.
    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority> // 우선순위는 비교 할수있는 제네릭인자여야한다.
    {
        List<ValueTuple<TElement, TPriority>> _heap = new List<ValueTuple<TElement, TPriority>>(); // 컴파일러 구형이슈로 이름있는 ValueTuple를 못읽는다.

        //public int Count => _heap.Count; // 컴파일러가 구형이라 식 본문을 읽을줄 모른다.
        public int GetCount() // heap에 대해선 크기만 공개해도 충분.
        {
            return _heap.Count;
        }

        public void Enqueue(TElement element, TPriority priority) // 해당 자료형의 값을 추가
        {
            _heap.Add((element, priority));

            int index = GetCount() - 1; // 맨 뒷부분에 추가한것.

            while (index > 0) // 부모와 반복 비교하면서 부모보다 작으면 상승.
            {
                int parentIndex = (index - 1) / 2;
                if (_heap[index].Item2.CompareTo(_heap[parentIndex].Item2) < 0) // 비교후 자식이 더 작으면 0 미만. 2 -4 같이 부모가 더클때 음수임.
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else // 자식값이 부모 이상이면 중단.
                    break;
            }
        }

        public TElement Dequeue()
        {
            TElement root = _heap[0].Item1; // 작은 값이 부모니 항상 루트가 최솟값. 이후 과정은 이진트리를 유지하기 위한 과정

            Swap(0, GetCount() - 1); // 루트 <-> 마지막 원소 스왑

            _heap.RemoveAt(GetCount() - 1); // 루트랑 마지막값은 스왑했으니 필요X 가비지 제거. 리스트의 마지막 원소 제거라 비용적음.

            int index = 0;

            // 마지막 값을 루트로 가져왔으니 다시 제자리로 돌려두면서 동시에 이진힙의 특성인
            // 부모가 자식보다 작음을 유지하면서 내려가주면 다시 힙 복구다.

            while (index < GetCount() - 1)
            {
                TPriority minPriority = _heap[index].Item2;

                int swapIndex = index;

                if (index * 2 + 1 < GetCount() && _heap[index].Item2.CompareTo(_heap[index * 2 + 1].Item2) > 0) // 부모 - 자식 > 0 이면 자식이 더 작은거니 스왑가능.
                {
                    swapIndex = index * 2 + 1; // 왼쪽 자식이 더 작으니 미리 기록.
                }

                if (index * 2 + 2 < GetCount() && _heap[swapIndex].Item2.CompareTo(_heap[index * 2 + 2].Item2) > 0) // 부모 혹은 왼쪽자식 중 작은 우선순위랑 비교해서 스왑가능 여부 체크.
                {
                    swapIndex = index * 2 + 2;
                }

                if (index == swapIndex)
                {
                    break;
                }

                Swap(index, swapIndex);
                index = swapIndex;
            }

            return root;
        }

        void Swap(int index1, int index2)
        {
            var temp = _heap[index1]; // 값,원소.

            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

    }
}