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
        (int a, int b)[] tree = new (int, int)[n * 4];
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(input[i - 1]);
        }

        int m = int.Parse(sr.ReadLine());

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int c = int.Parse(line[2]);

            if (a == 1)
            {
                Update(1, 1, n, b, c);
            }
            else if (a == 2)
            {
                sw.WriteLine(Query(1, 1, n, b, c, true));
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, b, c, false));
            }
        }

        (int a, int b) Build(int node, int start, int end)
        {
            if (start == end)
            {
                if (arr[start] % 2 == 0)
                    return tree[node] = (1, 0);
                else
                    return tree[node] = (0, 1);
            }

            int mid = (start + end) / 2;
            (int a, int b) leftnode = Build(node * 2, start, mid);
            (int a, int b) rightnode = Build(node * 2 + 1, mid + 1, end);
            return tree[node] = (leftnode.a + rightnode.a, leftnode.b + rightnode.b);
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (index < start || index > end)
            {
                return;
            }

            if (start == end)
            {
                if (value % 2 == 0)
                {
                    tree[node] = (1, 0);
                }
                else
                {
                    tree[node] = (0, 1);
                }
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
            tree[node] = (tree[node * 2].a + tree[node * 2 + 1].a, tree[node * 2].b + tree[node * 2 + 1].b);
        }

        int Query(int node, int start, int end, int left, int right, bool isA)
        {
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                if (isA)
                    return tree[node].a;
                else
                    return tree[node].b;
            }


            int mid = (start + end) / 2;
            return Query(node * 2, start, mid, left, right, isA) + Query(node * 2 + 1, mid + 1, end, left, right, isA);
        }
    }
}
