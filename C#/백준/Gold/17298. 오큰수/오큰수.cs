using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        Stack<int> stack = new Stack<int>();

        int[] output = new int[n];
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] < arr[i])
            {
                output[stack.Pop()] = arr[i];
            }
            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            output[stack.Pop()] = -1;
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(output[i]).Append(' ');
        }
        sw.Write(sb);
    }
}
