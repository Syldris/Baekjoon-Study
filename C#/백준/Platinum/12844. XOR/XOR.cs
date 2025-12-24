#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 262144));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 262144));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        int[] tree = new int[n * 4];
        int[] lazy = new int[n * 4];

        Build(1, 1, n);
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int left = line[1] + 1;
            int right = line[2] + 1;
            if (line[0] == 1)
            {
                int value = line[3];
                Update(1, 1, n, left, right, value);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, left, right));
            }
        }

        int Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start - 1];
            }
            int mid = (start + end) / 2;

            return tree[node] = Build(node * 2, start, mid) ^ Build(node * 2 + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (right < start || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                if ((end - start) % 2 == 0)
                {
                    tree[node] ^= value;
                }
                if (start != end)
                {
                    lazy[node] ^= value;
                }
                return;
            }

            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }
            int mid = (start + end) / 2;

            Update(node * 2, start, mid, left, right, value);
            Update(node * 2 + 1, mid + 1, end, left, right, value);
            tree[node] = tree[node * 2] ^ tree[node * 2 + 1];
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (end < left || right < start)
            {
                return 0;
            }
            if (left <= start && end <= right)
            {
                return tree[node];
            }

            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }

            int mid = (start + end) / 2;

            return Query(node * 2, start, mid, left, right) ^ Query(node * 2 + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            if (start != end)
            {
                int mid = (start + end) / 2;

                lazy[node * 2] ^= lazy[node];
                lazy[node * 2 + 1] ^= lazy[node];

                if ((mid - start) % 2 == 0)
                    tree[node * 2] ^= lazy[node];

                if ((end - mid + 1) % 2 == 0)
                    tree[node * 2 + 1] ^= lazy[node];
            }
            lazy[node] = 0;
        }
    }
}