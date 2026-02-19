#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        long maxEnergy = long.Parse(input[1]);
        int startEnergy = int.Parse(input[2]);
        long curEnergy = 0;

        int endPos = int.Parse(input[3]);
        int curPos = 0;

        long totalCost = 0;

        // 이중 우선순위 큐 (딕셔너리로 정보 관리)
        PriorityQueue<int, int> minHeap = new();
        PriorityQueue<int, int> maxHeap = new();
        Dictionary<int, long> dict = new();

        QueueInsert(0, startEnergy);

        (int pos, int value)[] gasStation = new (int, int)[n];

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            gasStation[i] = (line[0], line[1]);
        }

        Array.Sort(gasStation); // 주유소는 거리순서로 방문함

        for (int i = 0; i < n; i++)
        {
            (int nextPos, int energyCost) = gasStation[i];

            if (!Move(nextPos - curPos))
            {
                sw.Write(-1);
                return;
            }
            curPos = nextPos;

            QueueInsert(energyCost, endPos - curPos); // 남은 이동거리만큼 가능한 채워보기
        }

        if (!Move(endPos - curPos))
        {
            sw.Write(-1);
            return;
        }

        sw.Write(totalCost);

        // 용량 상관없이 전부채우고 넘친 용량만큼 비싼연료부터 버리자!
        void QueueInsert(int cost, int number)
        {
            minHeap.Enqueue(cost, cost);
            maxHeap.Enqueue(cost, -cost);

            if (!dict.ContainsKey(cost))
                dict.Add(cost, number);
            else
                dict[cost] += number;

            curEnergy += number;
            while (curEnergy > maxEnergy) // 연료가 넘치면 최대용량에 맞게 빼주기
            {
                int heapCost = maxHeap.Dequeue();
                if (dict[heapCost] != 0)
                {
                    if (curEnergy - dict[heapCost] >= maxEnergy) // 연료 cost 하나 전부 다빼도 되는 경우
                    {
                        curEnergy -= (int)dict[heapCost];
                        dict[heapCost] = 0;
                    }
                    else // 일정 부분만 빼야하는 경우
                    {
                        long amount = curEnergy - maxEnergy;

                        curEnergy -= amount;
                        dict[heapCost] -= amount;
                        maxHeap.Enqueue(heapCost, -heapCost); // 재삽입
                    }
                }
            }
        }

        // 이동할땐 싼연료부터 소모하자!
        bool Move(long distance)
        {
            while (distance > 0 && minHeap.Count > 0)
            {
                int heapCost = minHeap.Dequeue();
                if (dict[heapCost] != 0)
                {
                    if (dict[heapCost] <= distance) // 연료 하나 다쓰면서 이동하는 경우
                    {
                        totalCost += heapCost * dict[heapCost];
                        curEnergy -= dict[heapCost];

                        distance -= dict[heapCost];
                        dict[heapCost] = 0;
                    }
                    else // 일정 부분만 쓰면서 이동
                    {
                        long amount = distance;
                        totalCost += heapCost * amount;
                        curEnergy -= amount;

                        distance = 0;
                        dict[heapCost] -= amount;
                        minHeap.Enqueue(heapCost, heapCost);
                    }
                }
            }

            return distance == 0;
        }
    }
}