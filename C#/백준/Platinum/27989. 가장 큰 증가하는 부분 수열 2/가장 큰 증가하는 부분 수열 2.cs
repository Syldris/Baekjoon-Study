#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        long[] arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        long[] sorted = arr.Distinct().ToArray();
        Array.Sort(sorted);

        int rank = 0;
        Dictionary<long, int> dict = new(sorted.Length);

        for (int i = 0; i < sorted.Length; i++)
        {
            long x = sorted[i];
            dict[x] = ++rank;
        }

        long[] tree = new long[rank * 4];

        for (int i = 0; i < n; i++)
        {
            long num = arr[i];
            int compress = dict[num];

            long query = Query(1, 1, rank, 1, compress - 1);
            Update(1, 1, rank, compress, query + num);
        }

        sw.Write(Query(1, 1, rank, 1, rank));

        void Update(int node, int start, int end, int index, long value)
        {
            if (start == end)
            {
                tree[node] = value;
                return;
            }
            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value);
            }

            tree[node] = Math.Max(tree[node << 1], tree[(node << 1) + 1]);
        }

        long Query(int node, int start, int end, int left, int right)
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

            return Math.Max(Query(node << 1, start, mid, left, right), Query((node << 1) + 1, mid + 1, end, left, right));
        }
    }
}