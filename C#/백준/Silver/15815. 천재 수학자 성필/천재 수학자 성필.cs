#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string text = sr.ReadLine();

        Stack<int> stack = new Stack<int>();
        Queue<char> queue = new Queue<char>();

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if ('0' <= c && c <= '9')
            {
                if (queue.Count > 0) Operation();
                stack.Push(c - '0');
            }
            else
            {
                queue.Enqueue(c);
            }
        }

        Operation();
        sw.Write(stack.Pop());

        void Operation()
        {
            while (stack.Count > 1)
            {
                int a = stack.Pop();
                int b = stack.Pop();

                char c = queue.Dequeue();
                int value = c switch
                {
                    '+' => b + a,
                    '-' => b - a,
                    '*' => b * a,
                    '/' => b / a
                };
                stack.Push(value);
            }
        }
    }
}