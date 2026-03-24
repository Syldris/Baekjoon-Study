#nullable disable
public readonly struct Node
{
    public readonly int value;
    public readonly int left;
    public readonly int right;

    public Node(int value, int left, int right)
    {
        this.value = value;
        this.left = left;
        this.right = right;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Node[] tree = new Node[n * 4];

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] == 1)
            {
                Update(1, 1, n, line[1], line[2]);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, line[1], line[2]).value);
            }
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = new Node(1, arr[start - 1], arr[start - 1]);
                return;
            }

            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            Node leftNode = tree[node << 1];
            Node rightNode = tree[(node << 1) + 1];

            int value = leftNode.value + rightNode.value;
            if (leftNode.right == rightNode.left) // 인접부분이 같은 경우 연속 일치구간은 -1. 34|43 = 3
            {
                value--;
            }
            tree[node] = new Node(value, leftNode.left, rightNode.right);
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node] = new Node(1, value, value);
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

            Node leftNode = tree[node << 1];
            Node rightNode = tree[(node << 1) + 1];

            int totalValue = leftNode.value + rightNode.value;
            if (leftNode.right == rightNode.left) // 인접부분이 같은 경우 연속 일치구간은 -1. 34|43 = 3
            {
                totalValue--;
            }
            tree[node] = new Node(totalValue, leftNode.left, rightNode.right);
        }

        Node Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return new Node(-1, 0, 0);

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) >> 1;

            Node leftNode = Query(node << 1, start, mid, left, right);
            Node rightNode = Query((node << 1) + 1, mid + 1, end, left, right);

            if (leftNode.value == -1)  // 한쪽이 범위밖인 경우.
                return rightNode;

            else if (rightNode.value == -1)
                return leftNode;

            int value = leftNode.value + rightNode.value;
            if (leftNode.right == rightNode.left)
            {
                value--;
            }

            return new Node(value, leftNode.left, rightNode.right);
        }
    }
}