#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] tree = new int[n * 4];

        int m = int.Parse(sr.ReadLine());

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (a == 1)
            {
                int c = int.Parse(line[2]);
                Update(1, 1, n, b, c);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, b));
            }
        }

        int Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start - 1];
            }

            int mid = (start + end) / 2;

            return tree[node] = Build(node * 2, start, mid) + Build(node * 2 + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (index > end || index < start)
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

        int Query(int node, int start, int end, int value)
        {
            if (start == end)
            {
                return start;
            }

            int mid = (start + end) / 2;
            if (tree[node * 2] >= value)
            {
                return Query(node * 2, start, mid, value);
            }
            else
            {
                return Query(node * 2 + 1, mid + 1, end, value - tree[node * 2]);
            }
        }
    }
}
