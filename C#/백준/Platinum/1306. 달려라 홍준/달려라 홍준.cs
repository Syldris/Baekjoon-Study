#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        LinkedList<int> deque = new LinkedList<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);

            if (deque.First.Value < i - (2 * m - 2))
            {
                deque.RemoveFirst();
            }

            if (i >= 2 * m - 2)
                result.Add(arr[deque.First.Value]);
        }

        sw.Write(string.Join(" ", result));
    }
}
