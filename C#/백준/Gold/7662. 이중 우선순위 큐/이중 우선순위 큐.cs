#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 131072));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 65536));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            PriorityQueue<long, long> minHeap = new();
            PriorityQueue<long, long> maxHeap = new();
            Dictionary<long, long> dict = new Dictionary<long, long>();

            for (int i = 0; i < n; i++)
            {
                string[] line = sr.ReadLine().Split();
                long value = long.Parse(line[1]);
                if (line[0] == "I")
                {
                    minHeap.Enqueue(value, value);
                    maxHeap.Enqueue(value, -value);

                    if (!dict.ContainsKey(value))
                        dict.Add(value, 1);

                    else
                        dict[value]++;
                }
                else
                {
                    if (value == 1)
                    {
                        while (maxHeap.Count > 0)
                        {
                            long temp = maxHeap.Dequeue();
                            if (dict[temp] != 0)
                            {
                                dict[temp]--;
                                break;
                            }
                        }
                    }
                    else
                    {
                        while (minHeap.Count > 0)
                        {
                            long temp = minHeap.Dequeue();
                            if (dict[temp] != 0)
                            {
                                dict[temp]--;
                                break;
                            }
                        }
                    }
                }
            }

            long? max = null;
            long? min = null;

            while (maxHeap.Count > 0)
            {
                long temp = maxHeap.Dequeue();
                if (dict[temp] != 0)
                {
                    max = temp;
                    break;
                }
            }

            while (minHeap.Count > 0)
            {
                long temp = minHeap.Dequeue();
                if (dict[temp] != 0)
                {
                    min = temp;
                    break;
                }
            }

            if (max.HasValue && min.HasValue)
            {
                sw.WriteLine($"{max} {min}");
            }
            else
            {
                sw.WriteLine("EMPTY");
            }
        }
    }
}