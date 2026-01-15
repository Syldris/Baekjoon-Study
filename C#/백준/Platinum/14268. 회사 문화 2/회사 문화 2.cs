#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] tree = new int[n * 4];
        int[] lazy = new int[n * 4];

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
        }

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        for (int i = 2; i <= n; i++)
        {
            int a = arr[i - 1];
            graph[a].Add(i);
            graph[i].Add(a);
        }

        (int start, int end)[] range = new (int, int)[n + 1];
        int rank = 0;

        DFS(1, -1);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int query = line[0];

            if (query == 1)
            {
                int node = line[1];
                int value = line[2];

                (int left, int right) = range[node];
                Update(1, 1, n, left, right, value);
            }
            else
            {
                int node = line[1];
                int index = range[node].start;
                sw.WriteLine(Query(1, 1, n, index));
            }
        }

        void DFS(int node, int parent)
        {
            range[node].start = ++rank;

            foreach (var child in graph[node])
            {
                if (child == parent) continue;

                DFS(child, node);
            }
            range[node].end = rank;
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                if (start == end)
                    tree[node] += value;
                else
                    lazy[node] += value;
                return;
            }

            Push(node, start, end);

            int mid = (start + end) / 2;

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);
        }

        int Query(int node, int start, int end, int index)
        {
            if (start == end)
            {
                return tree[node];
            }

            Push(node, start, end);
            int mid = (start + end) / 2;

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
            if (lazy[node] == 0) return;

            tree[node << 1] += lazy[node];
            tree[(node << 1) + 1] += lazy[node];

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}