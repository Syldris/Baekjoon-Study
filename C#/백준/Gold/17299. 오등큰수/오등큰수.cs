using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder sb = new StringBuilder();
        
        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] output = new int[n];

        Dictionary<int,int> hash = new Dictionary<int,int>();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            if (hash.ContainsKey(arr[i]))
            {
                hash[arr[i]]++;
            }
            else
            {
                hash.Add(arr[i], 1);
            }
        }

        for (int i = 0; i < n; i++)
        {
            while(stack.Count > 0 && hash[arr[stack.Peek()]] < hash[arr[i]])
            {
                output[stack.Pop()] = arr[i];
            }
            stack.Push(i);
        }

        while(stack.Count > 0)
        {
            output[stack.Pop()] = -1;
        }

        for (int i = 0; i < n; i++)
        {
            sb.Append(output[i]).Append(' ');
        }
        sw.Write(sb);
    }
}
