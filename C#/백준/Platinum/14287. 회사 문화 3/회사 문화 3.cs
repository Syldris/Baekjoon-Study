#nullable disable
using System;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] tree = new int[n * 4];
        int[] lazy = new int[n * 4];

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        for (int i = 1; i < n; i++)
        {
            int index = arr[i];
            graph[index].Add(i + 1);
        }

        (int start, int end)[] range = new (int, int)[n + 1];
        int rank = 0;

        DFS(1, -1);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            if (line[0] == 1)
            {
                int index = line[1];
                int value = line[2];
                Update(1, 1, n, range[index].start, range[index].start, value);
            }
            else
            {
                int index = line[1];
                sw.WriteLine(Query(1, 1, n, range[index].start, range[index].end));
            }
        }

        void DFS(int node, int parent)
        {
            range[node].start = ++rank;
            foreach (var child in graph[node])
            {
                DFS(child, node);
            }
            range[node].end = rank;
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return;
            }
            if (left <= start && end <= right)
            {
                tree[node] += value;
                lazy[node] += value;
                return;
            }

            Push(node, start, end);

            int mid = (start + end) / 2;

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return 0;
            }
            if (left <= start && end <= right)
            {
                return tree[node];
            }

            Push(node, start, end);

            int mid = (start + end) / 2;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);

        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            tree[node << 1] += lazy[node];
            tree[(node << 1) + 1] += lazy[node];
            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}