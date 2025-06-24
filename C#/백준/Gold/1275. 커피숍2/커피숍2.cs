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

        long[] arr = new long[n + 1];
        long[] tree = new long[n * 4];
        
        string[] inputs = sr.ReadLine().Split();
        for (int i = 1; i <= n; i++)
        {
            arr[i] = long.Parse(inputs[i - 1]);
        }

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int a = line[0], b = line[1], c = line[2], d = line[3];

            if (a > b)
            {
                (a, b) = (b, a);
            }

            sw.WriteLine(Query(1, 1, n, a, b));
            Update(1, 1, n, c, d);
        }

        long Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start];
            }

            int mid = (start + end) / 2;

            return tree[node] = Build(node * 2, start, mid) + Build(node * 2 + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int index, long value)
        {
            if(start > index || end < index)
                return;

            if (start == end)
            {
                tree[node] = value;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node * 2, start, mid, index, value);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, end, index, value);
            }

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if(start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
        }

    }
}
