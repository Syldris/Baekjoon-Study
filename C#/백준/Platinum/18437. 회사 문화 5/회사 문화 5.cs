#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 1; i < n; i++)
        {
            int parent = arr[i];
            graph[parent].Add(i + 1); // 상사 => 자식
        }

        (int start, int end)[] range = new (int, int)[n + 1];
        int rank = 0;

        DFS(1);

        int[] tree = new int[n * 4];
        int[] lazy = new int[n * 4]; // 현재노드가 자식노드에게 전파해야할값. 1 = ON, -1 = OFF

        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            (int left, int right) = range[line[1]];
            left++; // 자기자신 미포함

            if (line[0] == 1)
            {
                Update(1, 1, n, left, right, true);
            }
            else if (line[0] == 2)
            {
                Update(1, 1, n, left, right, false);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, left, right));
            }
        }

        void DFS(int node) // 상사 => 자식 방향 DAG비순환 그래프라 parent로 안막아도됨.
        {
            range[node].start = ++rank;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            range[node].end = rank;
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = 1;
                return;
            }

            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        void Update(int node, int start, int end, int left, int right, bool on)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                if (on)
                {
                    tree[node] = (end - start + 1);
                    lazy[node] = 1;
                }
                else
                {
                    tree[node] = 0;
                    lazy[node] = -1;
                }
                return;
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            Update(node << 1, start, mid, left, right, on);
            Update((node << 1) + 1, mid + 1, end, left, right, on);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

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
            if (lazy[node] == 0) // 넘기는 값이 없음.
                return;

            int mid = (start + end) >> 1;

            int leftRange = (mid - start) + 1;
            int rightRange = (end - (mid + 1)) + 1;

            lazy[node << 1] = lazy[node];
            lazy[(node << 1) + 1] = lazy[node];

            if (lazy[node] == 1) // ON.
            {
                tree[node << 1] = leftRange;
                tree[(node << 1) + 1] = rightRange;
            }
            else // OFF.
            {
                tree[node << 1] = 0;
                tree[(node << 1) + 1] = 0;
            }

            lazy[node] = 0;
        }
    }
}