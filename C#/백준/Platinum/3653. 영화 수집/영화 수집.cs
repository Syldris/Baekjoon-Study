#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int size = m + n;

            int[] pos = new int[n + 1];
            int[] tree = new int[size * 4];
            
            for (int i = 1; i <= n; i++)
            {
                pos[i] = m + i;
                Update(1, 1, size, pos[i], 1);
            }

            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int top = m;

            for (int i = 0; i < m; i++)
            {
                int value = line[i];
                sw.Write($"{Query(1, 1, size, 1, pos[value] - 1)} ");
                Update(1, 1, size, pos[value], 0);
                pos[value] = top;
                Update(1, 1, size, top--, 1);
            }
            sw.WriteLine();

            void Update(int node, int start, int end, int index, int value)
            {
                if (index < start || index > end)
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

                tree[node] = tree[node * 2] + tree[node * 2 + 1];
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
                int mid = (start + end) / 2;

                return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
            }
        }
    }
}
