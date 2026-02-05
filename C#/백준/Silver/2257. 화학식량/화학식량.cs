#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string input = sr.ReadLine();

        Stack<int> stack = new Stack<int>();
        foreach (char c in input)
        {
            if (c == '(')
            {
                stack.Push(-1);
            }
            else if (c == ')')
            {
                int value = 0;
                while (stack.Peek() != -1)
                {
                    value += stack.Pop();
                }
                stack.Pop();
                stack.Push(value);
            }
            else if ('1' <= c && c <= '9')
            {
                int value = stack.Pop();
                value *= c - '0';
                stack.Push(value);
            }
            else
            {
                stack.Push(formet(c));
            }
        }

        int result = 0;

        foreach (var item in stack)
        {
            result += item;
        }

        sw.Write(result);

        int formet(char c) => c switch
        {
            'H' => 1,
            'C' => 12,
            'O' => 16
        };
    }
}