#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        HashSet<long> hash = new();
        string[] input = sr.ReadLine().Split();
        long n = long.Parse(input[0]);
        long m = long.Parse(input[1]);

        Queue<long> queue = new();
        queue.Enqueue(n);
        while (queue.Count > 0)
        {
            long value = queue.Dequeue();
            if (value == m)
            {
                sw.Write("YES");
                return;
            }

            if (value % 2 == 0)
            {
                Enqueue(value / 2);
            }
            else
            {
                Enqueue(value / 2);
                Enqueue((value / 2) + 1);
            }

        }
        sw.Write("NO");

        void Enqueue(long value)
        {
            if (!hash.Contains(value))
            {
                queue.Enqueue(value);
                hash.Add(value);
            }
        }
    }
}