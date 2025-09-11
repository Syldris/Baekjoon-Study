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
        Stack<int> stack = new Stack<int>();
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); 
        int[] result = new int[n];
        
        for (int i = n - 1; i >= 0; i--)
        {
            int value = arr[i];
            while (stack.Count > 0 && value >= arr[stack.Peek()])
            {
                result[stack.Pop()] = i + 1;
            }
            stack.Push(i);
        }

        sw.Write(String.Join(' ', result));
    }
}
