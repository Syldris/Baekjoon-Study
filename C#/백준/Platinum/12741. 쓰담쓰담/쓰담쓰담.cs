#nullable disable
public readonly struct Node
{
    public readonly int min;
    public readonly int max;
    public readonly bool order = true;

    public Node(int min, int max, bool order)
    {
        this.min = min;
        this.max = max;
        this.order = order;
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

        int[] treeIndex = new int[n + 1];

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = line[1];
            int b = line[2];
            if (line[0] == 1)
            {
                sw.WriteLine(Query(1, 1, n, a, b).order ? "CS204" : "HSS090");
            }
            else
            {
                int aValue = tree[treeIndex[a]].min; // 순서만 알고있다면 매핑을 통해 바로 접근
                int bValue = tree[treeIndex[b]].min;

                Update(1, 1, n, a, bValue); // a 위치엔 이제 b가 섬
                Update(1, 1, n, b, aValue); // b 위치엔 a가 섬
            }
        }

        Node Build(int node, int start, int end)
        {
            if (start == end)
            {
                treeIndex[start] = node; // 위치 = 세그 인덱스
                return tree[node] = new Node(arr[start - 1], arr[start - 1], true);
            }

            int mid = (start + end) / 2;

            Node leftNode = Build(node << 1, start, mid);
            Node rightNode = Build((node << 1) + 1, mid + 1, end);

            bool order = leftNode.max <= rightNode.min && leftNode.order && rightNode.order;

            return tree[node] = new Node(Math.Min(leftNode.min, rightNode.min), Math.Max(leftNode.max, rightNode.max), order);
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node] = new Node(value, value, true);
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
                Update(node << 1, start, mid, index, value);
            else
                Update((node << 1) + 1, mid + 1, end, index, value);

            Node leftNode = tree[node << 1];
            Node rightNode = tree[(node << 1) + 1];

            bool order = leftNode.max <= rightNode.min && leftNode.order && rightNode.order;

            tree[node] = new Node(Math.Min(leftNode.min, rightNode.min), Math.Max(leftNode.max, rightNode.max), order);
        }

        Node Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return new Node(int.MaxValue, int.MinValue, true);

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            Node leftQuery = Query(node << 1, start, mid, left, right);
            Node rightQuery = Query((node << 1) + 1, mid + 1, end, left, right);

            bool order = leftQuery.max <= rightQuery.min && leftQuery.order && rightQuery.order;

            return new Node(Math.Min(leftQuery.min, rightQuery.min), Math.Max(leftQuery.max, rightQuery.max), order);
        }
    }
}