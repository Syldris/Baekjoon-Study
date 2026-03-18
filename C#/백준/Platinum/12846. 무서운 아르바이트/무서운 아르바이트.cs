#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Stack<int> stack = new Stack<int>(); // 오름차순 단조스택

        long result = 0;

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
            {
                int pop = stack.Pop();

                int left = stack.Count > 0 ? stack.Peek() + 1 : 0;
                int right = i - 1;

                long value = (long)arr[pop] * (right - left + 1);
                result = Math.Max(result, value);
            }

            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            int pop = stack.Pop();

            int left = stack.Count > 0 ? stack.Peek() + 1 : 0;
            int right = n - 1;

            long value = (long)arr[pop] * (right - left + 1);
            result = Math.Max(result, value);
        }

        sw.Write(result);
    }
}