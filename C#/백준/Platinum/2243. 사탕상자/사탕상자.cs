#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] tree = new int[4000000];

        for (int i = 0; i < n; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();

            if (line[0] == 1)
            {
                int value = Query(1, 1, 1000000, line[1]);
                sw.WriteLine(value);
                Update(1, 1, 1000000, value, -1);
            }
            else
            {
                Update(1, 1, 1000000, line[1], line[2]);
            }
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (index < start || index > end)
            {
                return;
            }
            if (start == end)
            {
                tree[node] = tree[node] + value;
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
