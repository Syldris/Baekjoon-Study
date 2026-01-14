#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int end = int.Parse(input[1]);

        long maxFual = long.Parse(input[2]);
        long fuel = 0;

        long result = 0;

        PriorityQueue<long, long> minHeap = new();
        PriorityQueue<long, long> maxHeap = new();
        Dictionary<long, long> dict = new();

        int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int pos = input2[0];
        QueueInsert(input2[1], input2[2]);

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int dist = line[0] - pos;
            int cost = line[1];
            int value = line[2];
            if (!Move(dist))
            {
                sw.Write(-1);
                return;
            }

            QueueInsert(cost, value);
            pos = line[0];
        }

        int diff = end - pos;
        if (!Move(diff))
        {
            sw.Write(-1);
            return;
        }

        sw.Write(result);

        void QueueInsert(long cost, long value)
        {
            minHeap.Enqueue(cost, cost);
            maxHeap.Enqueue(cost, -cost);
            fuel += value;

            if (!dict.ContainsKey(cost))
            {
                dict.Add(cost, value);
            }
            else
            {
                dict[cost] += value;
            }

            if (fuel > maxFual)
            {
                long diff = fuel - maxFual;
                while (maxHeap.Count > 0)
                {
                    long item = maxHeap.Dequeue();
                    if (dict[item] == 0) continue;

                    if (dict[item] >= diff)
                    {
                        dict[item] -= diff;
                        fuel = maxFual;

                        maxHeap.Enqueue(item, -item);// 사용후 재삽입
                        break;
                    }
                    else
                    {
                        diff -= dict[item];
                        fuel -= dict[item];

                        dict[item] = 0;
                    }
                }
            }
        }

        bool Move(long dist)
        {
            while (minHeap.Count > 0)
            {
                long cost = minHeap.Dequeue();
                if (dict[cost] == 0) continue;

                if (dict[cost] >= dist)
                {
                    result += cost * dist;
                    dict[cost] -= dist;
                    fuel -= dist;

                    minHeap.Enqueue(cost, cost); // 사용후 재삽입

                    return true;
                }
                else
                {
                    result += cost * dict[cost];
                    dist -= dict[cost];
                    fuel -= dict[cost];

                    dict[cost] = 0;
                }
            }
            return false;
        }
    }
}