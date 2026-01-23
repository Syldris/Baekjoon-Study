#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        LinkedList<int> deque = new LinkedList<int>();
        for (int i = 1; i <= n; i++)
        {
            deque.AddLast(i);
        }

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int result = 0;

        for (int i = 0; i < m; i++)
        {
            int left = 0;
            while (deque.First() != arr[i])
            {
                int node = deque.First();
                deque.RemoveFirst();
                deque.AddLast(node);
                left++;
            }

            int right = n - i - left;

            deque.RemoveFirst();

            result += Math.Min(left, right);
        }

        sw.Write(result);
    }
}