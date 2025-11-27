#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        Queue<int> queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            queue.Enqueue(i);
        }

        for (int i = 1; i < n; i++)
        {
            int mod = n + 1 - i;
            long value = Pow3(i) % mod;
            if (value == 0)
            {
                value = mod;
            }

            int num = 0;
            int[] arr = new int[value];
            while (++num != value)
            {
                arr[num] = queue.Dequeue();
            }
            queue.Dequeue();

            for (int v = 1; v < value; v++)
            {
                queue.Enqueue(arr[v]);
            }
        }

        sw.Write(queue.Dequeue());

        long Pow3(long i)
        {
            return i * i * i;
        }
    }
}