#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] input = sr.ReadLine().Split();
        
        int[] arr = new int[n + 1];
        int[] tree = new int[n * 4];
        
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(input[i - 1]);
        }
        
        int m = int.Parse(sr.ReadLine());

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();

            if (line[0] == 1)
            {
                Update(1, 1, n, line[1], line[2]);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, line[1], line[2]));
            }
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

        void Update(int node, int start, int end, int index, int value)
        {
            if (start > index || end < index)
            {
                return;
            }
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
            tree[node] = Math.Min(tree[node * 2], tree[node * 2 + 1]);
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if(left > end || right < start)
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
