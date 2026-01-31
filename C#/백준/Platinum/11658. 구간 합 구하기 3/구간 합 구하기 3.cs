#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] board = new int[n, n];

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                board[x, y] = line[x];
            }
        }

        int[][] tree = new int[n][];

        for (int i = 0; i < n; i++)
        {
            tree[i] = new int[n * 4];
            Build(1, 1, n, tree[i], i);
        }

        for (int q = 0; q < m; q++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] == 0)
            {
                int y = line[1] - 1;
                int x = line[2];
                int value = line[3];
                Update(1, 1, n, x, value, tree[y]);
            }
            else
            {
                int y1 = line[1] - 1;
                int x1 = line[2];
                int y2 = line[3] - 1;
                int x2 = line[4];

                sw.WriteLine(Query(1, 1, n, x1, x2, y1, y2));
            }
        }

        int Build(int node, int start, int end, int[] tree, int y)
        {
            if (start == end)
            {
                return tree[node] = board[start - 1, y];
            }

            int mid = (start + end) / 2;

            return tree[node] = Build(node << 1, start, mid, tree, y) + Build((node << 1) + 1, mid + 1, end, tree, y);
        }

        void Update(int node, int start, int end, int index, int value, int[] tree)
        {
            if (start == end)
            {
                tree[node] = value;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value, tree);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value, tree);
            }
            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        long Query(int node, int start, int end, int left, int right, int lowY, int highY)
        {
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                long value = 0;
                for (int i = lowY; i <= highY; i++)
                {
                    value += tree[i][node];
                }

                return value;
            }

            int mid = (start + end) / 2;

            return Query(node << 1, start, mid, left, right, lowY, highY) + Query((node << 1) + 1, mid + 1, end, left, right, lowY, highY);
        }
    }
}