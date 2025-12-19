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

        int[] tree = new int[n * 4];
        bool[] lazy = new bool[n * 4];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int t = int.Parse(line[0]);
            int start = int.Parse(line[1]);
            int end = int.Parse(line[2]);

            if (t == 0)
            {
                Update(1, 1, n, start, end);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, start, end));
            }
        }

        void Update(int node, int start, int end, int left, int right)
        {
            if (lazy[node])
            {
                Push(node, start, end);
            }
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                tree[node] = (end - start + 1) - tree[node];
                if (start != end)
                {
                    lazy[node * 2] = !lazy[node * 2];
                    lazy[node * 2 + 1] = !lazy[node * 2 + 1];
                }
                return;
            }

            int mid = (start + end) / 2;

            Update(node * 2, start, mid, left, right);
            Update(node * 2 + 1, mid + 1, end, left, right);

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return 0;
            }
            if (lazy[node])
            {
                Push(node, start, end);
            }
            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;
            return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            tree[node] = (end - start + 1) - tree[node];
            if (start != end)
            {
                lazy[node * 2] = !lazy[node * 2];
                lazy[node * 2 + 1] = !lazy[node * 2 + 1];
            }
            lazy[node] = false;
        }

    }
}