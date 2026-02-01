#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int k = int.Parse(input[0]);
        int n = int.Parse(input[1]);
        int c = int.Parse(input[2]);

        int[] tree = new int[n << 2];
        int[] lazy = new int[n << 2];

        int result = 0;

        (int start, int end, int people)[] arr = new (int start, int end, int people)[k];
        for (int i = 0; i < k; i++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]) - 1;
            int people = int.Parse(line[2]);

            arr[i] = (start, end, people);
        }

        arr = arr.OrderBy(x => x.end).OrderByDescending(x => x.start).ToArray();

        for (int i = 0; i < k; i++)
        {
            (int start, int end, int people) = arr[i];

            int query = Query(1, 1, n, start, end);

            int value = Math.Min(c - query, people);
            Update(1, 1, n, start, end, value);

            result += value;
        }

        sw.Write(result);

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                if (start != end)
                {
                    lazy[node] += value;
                }

                tree[node] += value;
                return;
            }

            int mid = (start + end) / 2;

            Push(node, start, end);
            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);

            tree[node] = Math.Max(tree[node << 1], tree[(node << 1) + 1]);
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

            return Math.Max(Query(node << 1, start, mid, left, right), Query((node << 1) + 1, mid + 1, end, left, right));
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            tree[node << 1] += lazy[node];
            tree[(node << 1) + 1] += lazy[node];

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}