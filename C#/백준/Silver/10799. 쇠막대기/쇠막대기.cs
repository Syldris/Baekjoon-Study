#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string text = sr.ReadLine();

        Stack<char> stack = new Stack<char>();
        long value = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '(') // 통나무 시작
            {
                stack.Push(text[i]);
            }
            else if (text[i - 1] == '(') // 레이저 ( )
            {
                stack.Pop();
                value += stack.Count;
            }
            else // 통나무 끝이니 1개+
            {
                value++; 
                stack.Pop();
            }
        }

        sw.Write(value);
    }
}