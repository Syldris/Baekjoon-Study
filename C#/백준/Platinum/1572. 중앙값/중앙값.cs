#nullable disable
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] tree = new int[65537 * 4];

        int[] arr = new int[n];
        long value = 0;

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
            Update(1, 0, 65536, arr[i], 1);
            if (i >= k - 1)
            {
                value += Query(1, 0, 65536, (k + 1) / 2);
                Update(1, 0, 65536, arr[i - k + 1], -1);
            }
        }

        sw.Write(value);


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

            if (mid >= index)
            {
                Update(node * 2, start, mid, index, value);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, end, index, value);
            }
            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        int Query(int node, int start, int end, int k)
        {
            if(start == end)
                return start;

            int mid = (start + end) / 2;
            if (tree[node * 2] >= k)
            {
                return Query(node * 2, start, mid, k);
            }
            else
            {
                return Query(node * 2 + 1, mid + 1, end, k - tree[node * 2]);
            }
        }
    }
}