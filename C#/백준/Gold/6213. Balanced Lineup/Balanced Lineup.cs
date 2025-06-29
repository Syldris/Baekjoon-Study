#nullable disable
using System;
class Program
{
    public struct Cow
    {
        public int min;
        public int max;

        public Cow(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr = new int[n + 1];
        Cow[] tree = new Cow[n * 4];
        
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        Build(1, 1, n);
        for (int i = 0; i < m; i++)
        {
            string[] inputs = sr.ReadLine().Split();
            int left = int.Parse(inputs[0]);
            int right = int.Parse(inputs[1]);

            Cow value = Query(1, 1, n, left, right);
            sw.WriteLine(value.max - value.min);
        }

        Cow Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = new Cow(arr[start], arr[start]);
            }

            int mid = (start + end) / 2;

            Cow left = Build(node * 2, start, mid);
            Cow right = Build(node * 2 + 1, mid + 1, end);
            return tree[node] = new Cow(Math.Min(left.min, right.min), Math.Max(left.max, right.max));
        }

        Cow Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return new Cow(int.MaxValue, int.MinValue);
            }
            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            Cow leftQuery = Query(node * 2, start, mid, left, right);
            Cow rightQuery = Query(node * 2 + 1, mid + 1, end, left, right);

            return new Cow(Math.Min(leftQuery.min, rightQuery.min), Math.Max(leftQuery.max, rightQuery.max));
        }
    }
}
