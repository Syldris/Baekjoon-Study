#nullable disable

public readonly struct Node
{
    public readonly long odd;
    public readonly long even;

    public Node(long odd, long even)
    {
        this.odd = odd;
        this.even = even;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Node[] tree = new Node[n * 4];
        Build(1, 1, n);
        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[1];
            int b = line[2];
            if (line[0] == 1)
            {
                Node node = Query(1, 1, n, a, b);
                sw.WriteLine(Math.Abs(node.odd - node.even));
            }
            else
            {
                Update(1, 1, n, a, b);
            }
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                if (start % 2 == 1)
                    tree[node] = new Node(arr[start - 1], 0); // 1index => 0-index
                else
                    tree[node] = new Node(0, arr[start - 1]);

                return;
            }

            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = new Node(tree[node << 1].odd + tree[(node << 1) + 1].odd, tree[node << 1].even + tree[(node << 1) + 1].even);
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                if (start % 2 == 1)
                    tree[node] = new Node(tree[node].odd + value, tree[node].even);
                else
                    tree[node] = new Node(tree[node].odd, tree[node].even + value);
                return;
            }
            int mid = (start + end) >> 1;
            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value);
            }
            tree[node] = new Node(tree[node << 1].odd + tree[(node << 1) + 1].odd, tree[node << 1].even + tree[(node << 1) + 1].even);
        }

        Node Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return new Node(0, 0);

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) >> 1;

            Node leftQuery = Query(node << 1, start, mid, left, right);
            Node rightQuery = Query((node << 1) + 1, mid + 1, end, left, right);
            return new Node(leftQuery.odd + rightQuery.odd, leftQuery.even + rightQuery.even);
        }
    }
}