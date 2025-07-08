#nullable disable
using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        const int max = 2000000;
        int[] tree = new int[max * 4];

        for (int i = 0; i < n; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();

            if (line[0] == 1)
            {
                Update(1, 1, max, line[1], 1);
            }
            else
            {
                int value = Query(1, 1, max, line[1]);
                sw.WriteLine(value);
                Update(1, 1, max, value, -1);
            }
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if(index < start || index > end)
                return;
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

        int Query(int node, int start, int end, int index)
        {
            if (start == end)
            {
                return start;
            }

            int mid = (start + end) / 2;

            if (index <= tree[node * 2])
            {
                return Query(node * 2, start, mid, index);
            }
            else
            {
                return Query(node * 2 + 1, mid + 1, end, index - tree[node * 2]);
            }
        }
    }
}
