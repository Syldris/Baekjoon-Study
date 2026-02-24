#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        LinkedList<int> deque = new();

        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            switch (line[0])
            {
                case 1: deque.AddFirst(line[1]); break;
                case 2: deque.AddLast(line[1]); break;
                case 3: sw.WriteLine(DequeueFirst()); break;
                case 4: sw.WriteLine(DequeueLast()); break;
                case 5: sw.WriteLine(deque.Count); break;
                case 6: sw.WriteLine(deque.Count == 0 ? 1 : 0); break;
                case 7: sw.WriteLine(deque.Count > 0 ? deque.First.Value : -1); break;
                case 8: sw.WriteLine(deque.Count > 0 ? deque.Last.Value : -1); break;
            }
        }

        int DequeueFirst()
        {
            int value = -1;
            if(deque.Count > 0)
            {
                value = deque.First.Value;
                deque.RemoveFirst();
            }
            return value;
        }

        int DequeueLast()
        {
            int value = -1;
            if (deque.Count > 0)
            {
                value = deque.Last.Value;
                deque.RemoveLast();
            }
            return value;
        }
    }
}