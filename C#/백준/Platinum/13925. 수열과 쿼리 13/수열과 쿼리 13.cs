#nullable disable
public struct Node
{
    public long add; // 덧셈
    public long multiple; // 곱

    public Node(long add, long multiple)
    {
        this.add = add;
        this.multiple = multiple;
    }

    const int Mod = 1000000007;

    public static Node operator +(Node left, Node right) // += 사용시 left <= right로 왼쪽이 피연산자임. 
    {
        // 왼쪽 (+5, *2) 일때 오른쪽 * 3 이라면 왼쪽 +은 *3으로 +15로 오른쪽 곱을 계산.
        long addValue = (left.add * right.multiple + right.add) % Mod;

        // 곱은 곱끼리 연산.
        long multipleValue = (left.multiple * right.multiple) % Mod;

        return new Node(addValue, multipleValue);
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        const int Mod = 1000000007;

        long[] tree = new long[n << 2];
        Node[] lazy = new Node[n << 2];

        Build(1, 1, n);

        int m = int.Parse(sr.ReadLine());

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int type = line[0];
            int left = line[1];
            int right = line[2];

            if (type != 4)
            {
                int value = line[3];
                RangeUpdate(1, 1, n, left, right, value, type);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, left, right));
            }
        }

        void Build(int node, int start, int end)
        {
            lazy[node].multiple = 1; // 모든 lazy는 1로 초기화.

            if (start == end)
            {
                tree[node] = arr[start - 1];
                return;
            }
            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = (tree[node << 1] + tree[(node << 1) + 1]) % Mod;
        }

        void RangeUpdate(int node, int start, int end, int left, int right, long value, int type) // type 1이면 덧셈, 2면 곱셈, 3이면 고정값.
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                if (type == 1) // 덧셈
                {
                    tree[node] = (tree[node] + (end - start + 1) * value) % Mod;
                    lazy[node].add += value; // +value, *1
                }
                else if (type == 2) // 곱셈
                {
                    tree[node] = (tree[node] * value) % Mod;
                    lazy[node] += new Node(0, value); // +0, *value
                }
                else // 고정값.
                {
                    tree[node] = ((end - start + 1) * value) % Mod;
                    lazy[node] += new Node(value, 0); // = value, *0 으로 이전값은 덧셈 곱셈 전부 0이되고, +value만 남음.
                }
                return;
            }

            int mid = (start + end) >> 1;
            Push(node, start, end);

            RangeUpdate(node << 1, start, mid, left, right, value, type);
            RangeUpdate((node << 1) + 1, mid + 1, end, left, right, value, type);

            tree[node] = (tree[node << 1] + tree[(node << 1) + 1]) % Mod;
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            Push(node, start, end);

            int mid = (start + end) >> 1;
            return (Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right)) % Mod;
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node].add == 0 && lazy[node].multiple == 1)
                return;

            int mid = (start + end) >> 1;

            // 기존값에 곱셈부터. 
            tree[node << 1] = (tree[node << 1] * lazy[node].multiple) % Mod;
            tree[(node << 1) + 1] = (tree[(node << 1) + 1] * lazy[node].multiple) % Mod;

            int leftRange = mid - start + 1;
            int rightRange = end - mid;

            // 곱셈후 덧셈.
            tree[node << 1] = (tree[node << 1] + lazy[node].add * leftRange) % Mod;
            tree[(node << 1) + 1] = (tree[(node << 1) + 1] + lazy[node].add * rightRange) % Mod;

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node].add = 0;
            lazy[node].multiple = 1;
        }
    }
}