#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 22);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        int[] tree = new int[n * 4];
        int[] lazy = new int[n * 4];

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] == 1)
            {
                int a = line[1] + 1;
                int b = line[2] + 1;
                int c = line[3];
                Update(1, 1, n, a, b, c);
            }
            else
            {
                int index = line[1] + 1;
                sw.WriteLine(Query(1, 1, n, index));
            }
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = arr[start - 1];
                return;
            }

            int mid = (start + end) / 2;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                if (start == end)
                    tree[node] ^= value;

                else
                    lazy[node] ^= value;
                return;
            }

            int mid = (start + end) / 2;
            Push(node, start, end);

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);
        }

        int Query(int node, int start, int end, int index)
        {
            if (start == end)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;
            Push(node, start, end);

            if (index <= mid)
            {
                return Query(node << 1, start, mid, index);
            }
            else
            {
                return Query((node << 1) + 1, mid + 1, end, index);
            }
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            tree[node << 1] ^= lazy[node];
            tree[(node << 1) + 1] ^= lazy[node];

            lazy[node << 1] ^= lazy[node];
            lazy[(node << 1) + 1] ^= lazy[node];

            lazy[node] = 0;
        }
    }
}