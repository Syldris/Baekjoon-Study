#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        long[] tree = new long[n * 4];
        long[] lazy = new long[n * 4];

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] == 1)
            {
                int left = line[1];
                int right = line[2];
                int value = line[3];
                Update(1, 1, n, left, right, value);
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

            Build(node * 2, start, mid);
            Build(node * 2 + 1, mid + 1, end);
            return tree[node];
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }

            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                if (start == end)
                {
                    tree[node] += value;
                }
                else
                {
                    lazy[node * 2] += value;
                    lazy[node * 2 + 1] += value;
                }
                return;
            }

            int mid = (start + end) / 2;

            Update(node * 2, start, mid, left, right, value);
            Update(node * 2 + 1, mid + 1, end, left, right, value);
        }

        long Query(int node, int start, int end, int index)
        {
            if (lazy[node] != 0)
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
            tree[node] += lazy[node];
            if (start != end)
            {
                lazy[node * 2] += lazy[node];
                lazy[node * 2 + 1] += lazy[node];
            }
            lazy[node] = 0;
        }
    }
}