#nullable disable
public readonly struct Node
{
    public readonly int min;
    public readonly int max;

    public Node(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        Node[] tree = new Node[n * 4];
        int[] keyToPos = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            keyToPos[arr[i]] = i + 1;
        }

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = line[1];
            int b = line[2];

            if (line[0] == 1)
            {
                // 키 = arr[위치]
                int aValue = arr[a - 1];
                int bValue = arr[b - 1];

                // 트리는 tree[키] = 위치 이다.

                Update(1, 1, n, aValue, b);
                Update(1, 1, n, bValue, a);

                arr[a - 1] = bValue;
                arr[b - 1] = aValue;
            }
            else
            {
                Node node = Query(1, 1, n, a, b);
                sw.WriteLine(node.max - node.min == b - a ? "YES" : "NO");
            }
        }

        Node Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = new Node(keyToPos[start], keyToPos[start]);
            }

            int mid = (start + end) / 2;

            Node leftNode = Build(node << 1, start, mid);
            Node rightNode = Build((node << 1) + 1, mid + 1, end);

            return tree[node] = new Node(Math.Min(leftNode.min, rightNode.min), Math.Max(leftNode.max, rightNode.max));
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node] = new Node(value, value);
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

            Node leftNode = tree[node << 1];
            Node rightNode = tree[(node << 1) + 1];

            tree[node] = new Node(Math.Min(leftNode.min, rightNode.min), Math.Max(leftNode.max, rightNode.max));
        }

        Node Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return new Node(int.MaxValue, int.MinValue);

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            Node leftNode = Query(node << 1, start, mid, left, right);
            Node rightNode = Query((node << 1) + 1, mid + 1, end, left, right);

            return new Node(Math.Min(leftNode.min, rightNode.min), Math.Max(leftNode.max, rightNode.max));
        }
    }
}