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

        long[] tree = new long[4 * n];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);

            if (a == 1)
            {
                Update(1, 1, n, b, c);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, b, c));
            }
        }

        void Update(int node, int start, int end, int index, long value)
        {
            if (index < start || index > end)
            {
                return;
            }
            if (start == end)
            {
                tree[node] += value;
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
            if (start > right || left > end)
            {
                return 0;
            }
            
            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
        }
    }
}
