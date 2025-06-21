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
        int m = int.Parse(input[1]);

        int[] arr = new int[n + 1];
        int[] tree = new int[4 * n];
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int left = int.Parse(line[0]);
            int right = int.Parse(line[1]);

            sw.WriteLine(Query(1, 1, n, left, right));
        }

        int Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start];
            }

            int mid = (start + end) / 2;
            return tree[node] = Math.Min(Build(node * 2, start, mid), Build(node * 2 + 1, mid + 1, end));
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return int.MaxValue;
            }

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            return Math.Min(Query(node * 2, start, mid, left, right), Query(node * 2 + 1, mid + 1, end, left, right));
        }
    }
}
