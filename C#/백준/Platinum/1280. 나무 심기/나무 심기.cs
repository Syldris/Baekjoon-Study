#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        const int max = 200001;
        const int mod = 1000000007;
        long[,] tree = new long[max * 4, 2];

        long value = 1;

        int first = int.Parse(sr.ReadLine()) + 1;
        Update(1, 1, max, first, first);

        for (int i = 1; i < n; i++)
        {
            int node = int.Parse(sr.ReadLine()) + 1;

            Update(1, 1, max, node, node);

            (long value, long count) leftQuery = Query(1, 1, max, 1, node - 1);
            (long value, long count) rightQuery = Query(1, 1, max, node + 1, max);

            long cost = 0;

            if (leftQuery.count == 0 && rightQuery.count == 0)
            {
                value = 0;
                break;
            }

            cost += (node * leftQuery.count - leftQuery.value);
            cost += (rightQuery.value - node * rightQuery.count);

            value = (value * (cost % mod)) % mod;
        }

        sw.Write(value);

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node, 0] += value;
                tree[node, 1]++;
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

            tree[node, 0] = (tree[node << 1, 0] + tree[(node << 1) + 1, 0]);
            tree[node, 1] = (tree[node << 1, 1] + tree[(node << 1) + 1, 1]);
        }

        (long value, long count) Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return (0, 0);
            }

            if (left <= start && end <= right)
            {
                return (tree[node, 0], tree[node, 1]);
            }

            int mid = (start + end) / 2;

            (long value, long count) leftQuery = Query(node << 1, start, mid, left, right);
            (long value, long count) rightQuery = Query((node << 1) + 1, mid + 1, end, left, right);

            return (leftQuery.value + rightQuery.value, leftQuery.count + rightQuery.count);
        }
    }
}