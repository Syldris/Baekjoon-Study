#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        (int start, int end)[] pos = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split(' ');
            pos[i] = (int.Parse(input[0]), int.Parse(input[1]));
        }
        Array.Sort(pos);

        (int start, int end)[] lineRange = new (int, int)[n + 1];

        lineRange[1] = pos[0];
        int result = 1;

        PriorityQueue<int, int> queue = new();
        queue.Enqueue(pos[0].end, pos[0].end);

        for (int i = 1; i < n; i++)
        {
            (int start, int end) = pos[i];

            while (queue.Count > 0 && start >= queue.Peek())
            {
                queue.Dequeue();
            }

            queue.Enqueue(end, end);
            result = Math.Max(queue.Count, result);
        }
        sw.Write(result);
    }
}