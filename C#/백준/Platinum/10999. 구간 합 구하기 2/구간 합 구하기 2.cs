#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        long[] arr = new long[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = long.Parse(sr.ReadLine());
        }
        long[] tree = new long[n * 4];
        long[] lazy = new long[n * 4];

        Build(1, 1, n);
        for (int i = 0; i < m + k; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            if (a == 1)
            {
                int start = int.Parse(line[1]);
                int end = int.Parse(line[2]);
                long value = long.Parse(line[3]);
                Update(1, 1, n, start, end, value);
            }
            else
            {
                int start = int.Parse(line[1]);
                int end = int.Parse(line[2]);
                sw.WriteLine(Query(1, 1, n, start, end));
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

        void Update(int node, int start, int end, int left, int right, long value)
        {
            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }

            if (left > end || right < start)
            {
                return;
            }
            if (left <= start && end <= right)
            {
                tree[node] += (end - start + 1) * value;
                if (start != end)
                {
                    lazy[node * 2] += value;
                    lazy[node * 2 + 1] += value;
                }
                return;
            }

            int mid = (start + end) / 2;
            Update(node * 2, start, mid, left, right, value);
            Update(node * 2 + 1, mid + 1, end, left, right, value);

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }

            if (left > end || right < start)
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

        void Push(int node, int start, int end)
        {
            tree[node] += (end - start + 1) * lazy[node];

            if (start != end)
            {
                lazy[node * 2] += lazy[node];
                lazy[node * 2 + 1] += lazy[node];
            }
            lazy[node] = 0;
        }
    }
}