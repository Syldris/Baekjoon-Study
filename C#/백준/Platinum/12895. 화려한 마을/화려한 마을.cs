#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int t = int.Parse(input[1]);
        int q = int.Parse(input[2]);

        int[] tree = new int[n << 2];
        int[] lazy = new int[n << 2];

        Build(1, 1, n);

        for (int i = 0; i < q; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[1]);
            int b = int.Parse(line[2]);

            if (a > b) (a, b) = (b, a);

            if (line[0] == "C")
            {
                int color = int.Parse(line[3]);
                Update(1, 1, n, a, b, color);
            }
            else
            {
                int value = Query(1, 1, n, a, b);
                int result = 0;

                for (int k = 1; k <= 30; k++)
                {
                    int bit = (value >> k) & 1;
                    result += bit;
                }

                sw.WriteLine(result);
            }
        }

        void Build(int node, int start, int end)
        {
            tree[node] = 1 << 1;

            if (start == end)
            {
                return;
            }

            int mid = (start + end) / 2;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int left, int right, int color)
        {
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                if (start != end)
                {
                    lazy[node] = 1 << color;
                }

                tree[node] = 1 << color;
                return;
            }

            int mid = (start + end) / 2;

            Push(node, start, end);
            Update(node << 1, start, mid, left, right, color);
            Update((node << 1) + 1, mid + 1, end, left, right, color);

            tree[node] = tree[node << 1] | tree[(node << 1) + 1];
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
            Push(node, start, end);

            return Query(node << 1, start, mid, left, right) | Query((node << 1) + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            tree[node << 1] = lazy[node];
            tree[(node << 1) + 1] = lazy[node];

            lazy[node << 1] = lazy[node];
            lazy[(node << 1) + 1] = lazy[node];

            lazy[node] = 0;
        }
    }
}