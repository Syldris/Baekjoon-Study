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

        long[] arr = new long[n + 1];
        long[] tree = new long[4 * n];


        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        Build(1, 1, n);

        for (int i = 0; i < m + k; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            if (line[0] == 1)
            {
                Update(1, 1, n, line[1], line[2]);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, line[1], line[2]));
            }
        }

        long Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[end];
            }

            int mid = (start + end) / 2;

            return tree[node] = Build(node * 2, start, mid) * Build(node * 2 + 1, mid + 1, end) % 1000000007;
        }

        void Update(int node, int start, int end, int index, long value)
        {
            if (start > index || end < index)
            {
                return;
            }

            if (start == end)
            {
                tree[node] = value;
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

            tree[node] = tree[node * 2] * tree[node * 2 + 1] % 1000000007;
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return 1;
            }

            if (start >= left && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;
            return Query(node * 2, start, mid, left, right) * Query(node * 2 + 1, mid + 1, end, left, right) % 1000000007; 
        }

    }
}