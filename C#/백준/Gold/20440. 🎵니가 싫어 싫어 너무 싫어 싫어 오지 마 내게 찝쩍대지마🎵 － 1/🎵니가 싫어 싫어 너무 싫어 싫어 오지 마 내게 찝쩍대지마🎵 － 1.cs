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
        (int start, int end) range = pos[0];

        PriorityQueue<(int start, int end), int> queue = new();
        queue.Enqueue((pos[0].start, pos[0].end), pos[0].end);

        for (int i = 1; i < n; i++)
        {
            (int start, int end) = pos[i];
            while (queue.Count > 0 && start >= queue.Peek().end)
            {
                queue.Dequeue();
            }
            queue.Enqueue((start, end), end);
            int value = queue.Count;

            if (value > result)
            {
                end = Math.Min(queue.Peek().end, end);
                range = (start, end);
                result = value;
            }
            else if (value == result)
            {
                if (range.start == start && end > range.end)
                {
                    end = Math.Min(queue.Peek().end, end);
                    range = (start, end);
                }
                else if (start == range.end)
                {
                    range.end = Math.Min(queue.Peek().end, end);
                }
            }
        }
        sw.WriteLine(result);
        sw.WriteLine($"{range.start} {range.end}");
    }
}