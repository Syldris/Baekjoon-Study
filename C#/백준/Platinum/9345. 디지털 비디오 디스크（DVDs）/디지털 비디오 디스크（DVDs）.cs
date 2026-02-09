#nullable disable
class Program
{
    public readonly struct Node
    {
        public readonly long value;
        public readonly int min;
        public readonly int max;

        public Node(long value, int min, int max)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
    }

    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 22);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int testcase = int.Parse(sr.ReadLine());

        long[] sum = new long[100001];
        for (int i = 1; i <= 100000; i++)
        {
            sum[i] = sum[i - 1] + i;
        }

        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            Node[] tree = new Node[n * 4];
            int[] reafNodePos = new int[n + 1];
            Build(1, 1, n);

            for (int i = 0; i < k; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int a = line[1] + 1;
                int b = line[2] + 1;

                if (line[0] == 0)
                {
                    int reafA = reafNodePos[a];
                    int reafB = reafNodePos[b];

                    int aValue = (int)tree[reafA].value;
                    int bValue = (int)tree[reafB].value;

                    Update(1, 1, n, a, bValue);
                    Update(1, 1, n, b, aValue);
                }
                else
                {
                    long value = sum[b] - sum[a - 1];
                    Node node = Query(1, 1, n, a, b);
                    if (node.value == value && node.min == a && node.max == b)
                    {
                        sw.WriteLine("YES");
                    }
                    else
                    {
                        sw.WriteLine("NO");
                    }
                }
            }

            Node Build(int node, int start, int end)
            {
                if (start == end)
                {
                    reafNodePos[start] = node;
                    return tree[node] = new Node(start, start, start);
                }
                int mid = (start + end) / 2;

                Node left = Build(node << 1, start, mid);
                Node right = Build((node << 1) + 1, mid + 1, end);
                return tree[node] = new Node(left.value + right.value, Math.Min(left.min, right.min), Math.Max(left.max, right.max));
            }

            void Update(int node, int start, int end, int index, int value)
            {
                if (start == end)
                {
                    tree[node] = new Node(value, value, value);
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

                Node left = tree[node << 1];
                Node right = tree[(node << 1) + 1];

                tree[node] = new Node(left.value + right.value, Math.Min(left.min, right.min), Math.Max(left.max, right.max));
            }

            Node Query(int node, int start, int end, int left, int right)
            {
                if (start > right || end < left)
                    return new Node(0, int.MaxValue, int.MinValue);

                if (left <= start && end <= right)
                    return tree[node];

                int mid = (start + end) / 2;

                Node leftNode = Query(node << 1, start, mid, left, right);
                Node rightNode = Query((node << 1) + 1, mid + 1, end, left, right);

                return new Node(leftNode.value + rightNode.value, Math.Min(leftNode.min, rightNode.min), Math.Max(leftNode.max, rightNode.max));
            }
        }
    }
}