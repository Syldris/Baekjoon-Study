#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] tree = new int[n * 4];
        int[] lazy = new int[n * 4];

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<int>();

        int[] money = new int[n + 1];
        money[1] = int.Parse(sr.ReadLine());

        for (int i = 2; i <= n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            money[i] = a;
            graph[b].Add(i);
        }

        (int start, int end)[] range = new (int, int)[n + 1];
        int[] pos = new int[n + 1];
        int rank = 0;
        DFS(1, -1);
        Build(1, 1, n);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            if (line[0] == "p")
            {
                int a = int.Parse(line[1]);
                int value = int.Parse(line[2]);
                (int start, int end) = range[a];

                if(start != end)
                    Update(1, 1, n, start + 1, end, value);
            }
            else
            {
                int a = int.Parse(line[1]);

                int index = range[a].start;
                sw.WriteLine(Query(1, 1, n, index));
            }
        }

        void DFS(int node, int parent)
        {
            range[node].start = ++rank;
            pos[rank] = node;
            foreach (var child in graph[node])
            {
                if (child == parent) continue;

                DFS(child, node);
            }
            range[node].end = rank;
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                int nodePos = pos[start];
                tree[node] = money[nodePos];
                return;
            }

            int mid = (start + end) / 2;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);
            return;
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return;
            }

            if (left <= start && end <= right)
            {
                if (start == end)
                    tree[node] += value;
                else
                    lazy[node] += value;
                return;
            }

            int mid = (start + end) / 2;

            if (lazy[node] != 0) Push(node, start, end);

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);
        }

        int Query(int node, int start, int end, int index)
        {
            if (start == end)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            if (lazy[node] != 0) Push(node, start, end);

            if (index <= mid)
            {
                return Query(node << 1, start, mid, index);
            }
            else
            {
                return Query((node << 1) + 1, mid + 1, end, index);
            }
        }

        void Push(int node, int start, int end)
        {
            tree[node << 1] += lazy[node];
            tree[(node << 1) + 1] += lazy[node];

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}