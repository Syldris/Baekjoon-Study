#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }
        int[] sorted = arr.OrderBy(x => x).Distinct().ToArray();
        int rank = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (int num in sorted)
        {
            dict[num] = rank++;
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = dict[arr[i]];
        }

        int[] tree = new int[rank * 4];

        void Update(int node, int start, int end, int index)
        {
            if (start > index || index > end)
            {
                return;
            }
            if (start == end)
            {
                tree[node]++;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node * 2, start, mid, index);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, end, index);
            }

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        int Query(int node, int start, int end, int left, int right)
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

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine(Query(1, 0, rank, arr[i], rank) + 1);
            Update(1, 1, rank, arr[i]);
        }
    }
}
