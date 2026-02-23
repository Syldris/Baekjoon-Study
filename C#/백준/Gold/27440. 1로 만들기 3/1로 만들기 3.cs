#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        long n = long.Parse(sr.ReadLine());

        Queue<(long value, int count)> queue = new();
        queue.Enqueue((n, 0));

        HashSet<long> visited = new HashSet<long>();

        while (queue.Count > 0)
        {
            (long value, int count) = queue.Dequeue();
            if (value == 1)
            {
                sw.Write(count);
                return;
            }
            int nextCount = count + 1;

            if (value > 1 && !visited.Contains(value - 1))
                Enqueue(value - 1, nextCount);
            if (value % 2 == 0 && !visited.Contains(value / 2))
                Enqueue(value / 2, nextCount);
            if (value % 3 == 0 && !visited.Contains(value / 3))
                Enqueue(value / 3, nextCount);
        }

        void Enqueue(long value, int count)
        {
            queue.Enqueue((value, count));
            visited.Add(value);
        }
    }
}