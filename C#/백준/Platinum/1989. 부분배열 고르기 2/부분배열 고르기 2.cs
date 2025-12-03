#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        long[] prefix = new long[n + 1];

        int start = 1, end = 1;
        for (int i = 1; i <= n; i++)
        {
            prefix[i] = prefix[i - 1] + arr[i - 1];
        }

        Stack<int> stack = new Stack<int>();
        long result = 0;

        for (int i = 1; i <= n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek() - 1] > arr[i - 1])
            {
                int pop = stack.Pop();

                int left = stack.Count == 0 ? 0 : stack.Peek();
                int right = i - 1;
                long value = (prefix[right] - prefix[left]) * arr[pop - 1];
                if (value > result)
                {
                    result = value;
                    start = left + 1;
                    end = right;
                }
            }
            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            int pop = stack.Pop();

            int left = stack.Count == 0 ? 0 : stack.Peek();
            long value = (prefix[n] - prefix[left]) * arr[pop - 1];

            if (value > result)
            {
                result = value;
                start = left + 1;
                end = n;
            }
        }

        sw.WriteLine(result);
        sw.WriteLine($"{start} {end}");
    }
}