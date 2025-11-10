#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        bool[] visited = new bool[n + 1];

        PriorityQueue<int, int> max = new();
        PriorityQueue<int, int> min = new();

        int start = 0; int end = k;

        for (int i = start; i < end; i++)
        {
            max.Enqueue(arr[i], -arr[i]);
            min.Enqueue(arr[i], arr[i]);
        }

        if (max.Peek() - min.Peek() + 1 == k)
        {
            sw.WriteLine("YES");
            sw.WriteLine(string.Join(' ', arr[start..end]));
            return;
        }

        while (end != n)
        {
            visited[arr[start]] = true;
            while (visited[max.Peek()])
            {
                max.Dequeue();
            }
            while (visited[min.Peek()])
            {
                min.Dequeue();
            }
            max.Enqueue(arr[end], -arr[end]);
            min.Enqueue(arr[end], arr[end]);
            start++;
            end++;
            if (max.Peek() - min.Peek() + 1 == k)
            {
                sw.WriteLine("YES");
                sw.WriteLine(string.Join(' ', arr[start..end]));
                return;
            }
        }
        sw.WriteLine("NO");
    }
}