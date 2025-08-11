#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string first = sr.ReadLine();
            if (first == null)
            {
                break;
            }
            string[] input = first.Split(); 
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] tree = new int[n * 4];

            Build(1, 1, n);
            for (int i = 0; i < m; i++)
            {
                string[] line = sr.ReadLine().Split();
                int a = int.Parse(line[1]);
                int b = int.Parse(line[2]);
                if (line[0] == "C")
                {
                    Update(1, 1, n, a, b);
                }
                else
                {
                    int value = Query(1, 1, n, a, b);
                    if (value > 0)
                    {
                        sw.Write('+');
                    }
                    else if (value < 0)
                    {
                        sw.Write('-');
                    }
                    else
                    {
                        sw.Write('0');
                    }
                }
            }
            sw.WriteLine();
            int Build(int node, int start, int end)
            {
                if (start == end)
                {
                    return tree[node] = Sign(arr[start - 1]);
                }

                int mid = (start + end) / 2;
                return tree[node] = Build(node * 2, start, mid) * Build(node * 2 + 1, mid + 1, end);
            }

            void Update(int node, int start, int end, int index, int value)
            {
                if (index < start || index > end)
                {
                    return;
                }
                if (start == end)
                {
                    tree[node] = Sign(value);
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
                tree[node] = tree[node * 2] * tree[node * 2 + 1];
            }

            int Query(int node, int start, int end, int left, int right)
            {
                if (start > right || end < left)
                {
                    return 1;
                }
                if (left <= start && end <= right)
                {
                    return tree[node];
                }
                int mid = (start + end) / 2;

                return Query(node * 2, start, mid, left, right) * Query(node * 2 + 1, mid + 1, end, left, right);
            }

            int Sign(int value)
            {
                if (value == 0)
                    return 0;
                return value > 0 ? 1 : -1;
            }
        }
    }
}
