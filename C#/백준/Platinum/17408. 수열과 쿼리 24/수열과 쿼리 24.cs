#nullable disable
using System;
using System.IO;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        (int max1, int max2)[] tree = new (int, int)[n * 4];


        Build(1, 1, n);

        int m = int.Parse(sr.ReadLine());

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            if (line[0] == 1)
            {
                Update(1, 1, n, line[1], line[2]);
            }
            else
            {
                (int max1, int max2) = Query(1, 1, n, line[1], line[2]);
                sw.WriteLine(max1 + max2);
            }
        }


        (int max1, int max2) Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = (arr[start - 1], 0);
            }

            int mid = (start + end) / 2;

            (int max1, int max2) leftNode = Build(node << 1, start, mid);
            (int max1, int max2) rightNode = Build((node << 1) + 1, mid + 1, end);

            tree[node].max1 = Math.Max(leftNode.max1, rightNode.max1);
            tree[node].max2 = Math.Max(Math.Min(leftNode.max1, rightNode.max1), Math.Max(leftNode.max2, rightNode.max2));

            return tree[node];
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node].max1 = value;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value);
            }

            (int max1, int max2) leftNode = tree[node << 1];
            (int max1, int max2) rightNode = tree[(node << 1) + 1];

            tree[node].max1 = Math.Max(leftNode.max1, rightNode.max1);
            tree[node].max2 = Math.Max(Math.Min(leftNode.max1, rightNode.max1), Math.Max(leftNode.max2, rightNode.max2));

        }

        (int max1, int max2) Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return (0, 0);

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            (int max1, int max2) leftNode = Query(node << 1, start, mid, left, right);
            (int max1, int max2) rightNode = Query((node << 1) + 1, mid + 1, end, left, right);

            int max1 = Math.Max(leftNode.max1, rightNode.max1);
            int max2 = Math.Max(Math.Min(leftNode.max1, rightNode.max1), Math.Max(leftNode.max2, rightNode.max2));

            return (max1, max2);
        }
    }
}