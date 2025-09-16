#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        long result = 0;

        Stack<(long value, long count)> stack = new Stack<(long, long)>();

        for (int i = 0; i < n; i++)
        {
            long cur = long.Parse(sr.ReadLine());
            long cnt = 1;

            while (stack.Count > 0 && cur >= stack.Peek().value)
            {
                (long value, long count) = stack.Pop();
                result += count;
                if (value == cur)
                {
                    cnt += count;
                }
            }

            if (stack.Count > 0)
                result++;

            stack.Push((cur, cnt));
        }

        sw.Write(result);
    }
}
