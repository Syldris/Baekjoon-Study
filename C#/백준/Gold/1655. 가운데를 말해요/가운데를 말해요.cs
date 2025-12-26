#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        PriorityQueue<int, int> left = new();
        PriorityQueue<int, int> right = new();

        int start = int.Parse(sr.ReadLine());
        left.Enqueue(start, -start);
        sw.WriteLine(left.Peek());

        for (int i = 1; i < n; i++)
        {
            int value = int.Parse(sr.ReadLine());

            if (value <= left.Peek())
            {
                left.Enqueue(value,-value);
            }
            else
            {
                right.Enqueue(value, value);
            }

            if (left.Count > right.Count + 1)
            {
                int temp = left.Dequeue();
                right.Enqueue(temp, temp);
            }
            else if (left.Count < right.Count)
            {
                int temp = right.Dequeue();
                left.Enqueue(temp, -temp);
            }

            sw.WriteLine(left.Peek());
        }
    }
}