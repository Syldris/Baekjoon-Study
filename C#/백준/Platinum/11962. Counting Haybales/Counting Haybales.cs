#nullable disable
using System;
using System.IO;

public struct Node
{
    public long totalValue;
    public long minValue;
    public Node(long totalValue, long minValue)
    {
        this.totalValue = totalValue;
        this.minValue = minValue;
    }
    public static Node operator +(Node left, Node right)
    {
        return new Node(left.totalValue + right.totalValue, Math.Min(left.minValue, right.minValue));
    }
}

class Program
{
    static Node[] tree;
    static long[] lazy;

    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        tree = new Node[n * 4];
        lazy = new long[n * 4];

        Build(1, 1, n, arr);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[1]);
            int b = int.Parse(line[2]);
            if (line[0] == "M")
            {
                sw.WriteLine(Query(1, 1, n, a, b).minValue);
            }
            else if (line[0] == "S")
            {
                sw.WriteLine(Query(1, 1, n, a, b).totalValue);
            }
            else 
            {
                long c = long.Parse(line[3]);
                Update(1, 1, n, a, b, c);
            }
        }
    }

    static void Build(int node, int start, int end, int[] arr)
    {
        if (start == end)
        {
            tree[node] = new Node(arr[start - 1], arr[start - 1]);
            return;
        }
        int mid = (start + end) >> 1;
        Build(node << 1, start, mid, arr);
        Build((node << 1) + 1, mid + 1, end, arr);
        tree[node] = tree[node << 1] + tree[(node << 1) + 1];
    }

    static void Update(int node, int start, int end, int left, int right, long value)
    {
        if (start > right || end < left) return;
        if (left <= start && end <= right)
        {
            tree[node].totalValue += value * (end - start + 1);
            tree[node].minValue += value;
            lazy[node] += value;
            return;
        }
        int mid = (start + end) >> 1;
        Push(node, start, end);
        Update(node << 1, start, mid, left, right, value);
        Update((node << 1) + 1, mid + 1, end, left, right, value);
        tree[node] = tree[node << 1] + tree[(node << 1) + 1];
    }

    static Node Query(int node, int start, int end, int left, int right)
    {
        if (start > right || end < left)
            return new Node(0, long.MaxValue / 2);
        if (left <= start && end <= right)
            return tree[node];
        int mid = (start + end) >> 1;
        Push(node, start, end);
        return Query(node << 1, start, mid, left, right)
             + Query((node << 1) + 1, mid + 1, end, left, right);
    }

    static void Push(int node, int start, int end)
    {
        if (lazy[node] == 0) return;
        int mid = (start + end) >> 1;
        int l = node << 1, r = (node << 1) + 1;

        tree[l].totalValue += lazy[node] * (mid - start + 1);
        tree[l].minValue += lazy[node];
        lazy[l] += lazy[node];

        tree[r].totalValue += lazy[node] * (end - mid);
        tree[r].minValue += lazy[node];
        lazy[r] += lazy[node]; 

        lazy[node] = 0;
    }
}