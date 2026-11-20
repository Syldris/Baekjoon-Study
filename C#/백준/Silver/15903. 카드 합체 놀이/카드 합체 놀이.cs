#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] split = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int n = split[0];
        int m = split[1];

        PriorityQueue<long, long> queue = new PriorityQueue<long, long>();

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        // 작은 거끼리 합하는게 항상 이득
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(arr[i], arr[i]);
        }

        for (int i = 0; i < m; i++)
        {
            long x = queue.Dequeue();
            long y = queue.Dequeue();

            long value = x + y;
            queue.Enqueue(value, value);
            queue.Enqueue(value, value);
        }

        long answer = 0;
        while (queue.Count > 0)
        {
            answer += queue.Dequeue();
        }

        sw.Write(answer);
    }
}