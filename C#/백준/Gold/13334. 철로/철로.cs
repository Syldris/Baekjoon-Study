#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 65535));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        (int start, int end)[] arr = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] > line[1])
            {
                (line[0], line[1]) = (line[1], line[0]);
            }
            arr[i] = (line[0], line[1]);
        }
        arr = arr.OrderBy(x => x.end).ToArray();

        PriorityQueue<(int start, int end), int> queue = new();

        int len = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            (int start, int end) = arr[i];
            if (end - start <= len)
            {
                queue.Enqueue((start, end), start);
                while (queue.Count > 0 && end > queue.Peek().start + len)
                {
                    queue.Dequeue();
                }
                result = Math.Max(queue.Count, result);
            }
        }
        sw.Write(result);
    }
}