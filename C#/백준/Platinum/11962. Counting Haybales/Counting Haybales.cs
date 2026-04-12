#nullable disable
public struct Node
{
    public long totalValue;
    public long minValue;

    public Node(long totalValue, long minValue)
    {
        this.totalValue = totalValue;
        this.minValue = minValue;
    }

    public static Node operator +(Node left, Node right)
    {
        return new Node(left.totalValue + right.totalValue, Math.Min(left.minValue, right.minValue));
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Node[] tree = new Node[n * 4];
        long[] lazy = new long[n * 4];

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int left = int.Parse(line[1]);
            int right = int.Parse(line[2]);

            if (line[0] == "M")
            {
                sw.WriteLine(Query(1, 1, n, left, right).minValue);
            }
            else if (line[0] == "S")
            {
                sw.WriteLine(Query(1, 1, n, left, right).totalValue);
            }
            else
            {
                int value = int.Parse(line[3]);
                Update(1, 1, n, left, right, value);
            }
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = new Node(arr[start - 1], arr[start - 1]);
                return;
            }
            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        void Update(int node, int start, int end, int left, int right, long value)
        {
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                tree[node].totalValue += value * (end - start + 1);
                tree[node].minValue += value;
                lazy[node] += value;

                return;
            }

            int mid = (start + end) >> 1;
            Push(node, start, end);

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        Node Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return new Node(0, int.MaxValue);
            }

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) >> 1;
            Push(node, start, end);

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            int mid = (start + end) >> 1;

            tree[node << 1].totalValue += lazy[node] * (mid - start + 1);
            tree[(node << 1) + 1].totalValue += lazy[node] * (end - mid);


            tree[node << 1].minValue += lazy[node];
            tree[(node << 1) + 1].minValue += lazy[node];

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}