#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        StringBuilder sb = new StringBuilder();
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        int push = 0;

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(sr.ReadLine());

            while (value > stack.Peek())
            {
                stack.Push(++push);
                sb.AppendLine("+");
                if (push > n)
                {
                    sw.Write("NO");
                    return;
                }
            }
            while (stack.Peek() != value)
            {
                if (stack.Pop() == 0)
                {
                    sw.Write("NO");
                    return;
                }
                sb.AppendLine("-");
            }
            if (stack.Peek() == value)
            {
                stack.Pop();
                sb.AppendLine("-");
            }
        }

        sw.Write(sb);
    }
}