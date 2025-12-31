#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 1 << 16));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 1 << 16));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long[] tree = new long[n * 4];
        (long offset, int num)[] lazy = new (long, int)[n * 4];

        long[] prefix = new long[100001];
        for (int i = 1; i <= 100000; i++)
        {
            prefix[i] = prefix[i - 1] + i;
        }

        Build(1, 1, n);
        int q = int.Parse(sr.ReadLine());
        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            if (a == 1)
            {
                int left = line[1];
                int right = line[2];
                Update(1, 1, n, left, right);
            }
            else
            {
                int index = line[1];
                sw.WriteLine(Query(1, 1, n, index));
            }
        }

        long Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start - 1];
            }
            int mid = (start + end) / 2;
            return tree[node] = Build(node * 2, start, mid) + Build(node * 2 + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int left, int right)
        {
            if (lazy[node].num != 0)
            {
                Push(node, start, end);
            }
            if (start > right || end < left)
            {
                return;
            }
            if (left <= start && end <= right)
            {
                lazy[node].offset += (start - left + 1);
                lazy[node].num++;
                Push(node, start, end);
                return;
            }

            int mid = (start + end) / 2;

            Update(node * 2, start, mid, left, right);
            Update(node * 2 + 1, mid + 1, end, left, right);
            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        long Query(int node, int start, int end, int index)
        {
            if (lazy[node].num != 0)
            {
                Push(node, start, end);
            }
            if (start == end)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;
            if (index <= mid)
            {
                return Query(node * 2, start, mid, index);
            }
            else
            {
                return Query(node * 2 + 1, mid + 1, end, index);
            }
        }

        void Push(int node, int start, int end)
        {
            (long offset, int num) = lazy[node];
            int len = end - start + 1;
            tree[node] += len * offset + prefix[len - 1] * num;

            if (start != end)
            {
                int mid = (start + end) / 2;
                lazy[node * 2].offset += offset;
                lazy[node * 2].num += num;

                lazy[node * 2 + 1].offset += (mid + 1 - start) * num + offset;
                lazy[node * 2 + 1].num += num;
            }
            lazy[node] = (0, 0);
        }
    }
}