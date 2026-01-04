#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        List<int>[] tree = new List<int>[n + 1];

        int[] segTree = new int[n * 4];
        int[] lazy = new int[n * 4];

        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<int>();
        }

        for (int i = 1; i <= n; i++)
        {
            int node = arr[i - 1];
            if (node != -1)
                tree[node].Add(i);
        }

        int count = 0;
        (int start, int end)[] range = new (int, int)[n + 1];
        DFS(1, -1);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int q = line[0];

            if (q == 1)
            {
                int k = line[1];
                int value = line[2];
                (int left, int right) = range[k];
                Update(1, 1, n, left, right, value);
            }
            else
            {
                int k = line[1];
                int index = range[k].start;
                sw.WriteLine(Query(1, 1, n, index));
            }
        }

        void DFS(int node, int parent)
        {
            range[node].start = ++count;
            foreach (var child in tree[node])
            {
                if (child != parent)
                {
                    DFS(child, node);
                }
            }
            range[node].end = count;
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                segTree[node] += value;
                if (start != end)
                    lazy[node] += value;
                return;
            }

            int mid = (start + end) / 2;
            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }

            Update(node * 2, start, mid, left, right, value);
            Update(node * 2 + 1, mid + 1, end, left, right, value);
            segTree[node] = segTree[node * 2] + segTree[node * 2 + 1];
        }

        int Query(int node, int start, int end, int index)
        {
            if (start == end)
            {
                return segTree[node];
            }

            int mid = (start + end) / 2;
            if (lazy[node] != 0)
            {
                Push(node, start, end);
            }

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
            segTree[node * 2] += lazy[node];
            segTree[node * 2 + 1] += lazy[node];

            lazy[node * 2] += lazy[node];
            lazy[node * 2 + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}