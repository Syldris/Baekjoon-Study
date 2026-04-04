#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int q1 = int.Parse(input[1]);
        int q2 = int.Parse(input[2]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long[] tree = new long[n * 4];
        long[] lazy = new long[n * 4];

        Build(1, 1, n);

        for (int i = 0; i < q1 + q2; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int query = line[0];
            int left = line[1];
            int right = line[2];

            if (query == 1)
            {
                sw.WriteLine(Query(1, 1, n, left, right));
            }
            else
            {
                int value = line[3];
                Update(1, 1, n, left, right, value);
            }
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = arr[start - 1];
                return;
            }

            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                tree[node] += value * (end - start + 1);
                lazy[node] += value;

                return;
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0)
                return;

            int mid = (start + end) >> 1;
            int leftRange = (mid - start + 1);
            int rightRange = (end - mid);

            tree[node << 1] += lazy[node] * leftRange;
            tree[(node << 1) + 1] += lazy[node] * rightRange;

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}