#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        List<int>[] tree = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<int>();
        }

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            tree[a].Add(b);
            tree[b].Add(a);
        }

        int k = (int)Math.Floor(Math.Log(n, 2)) + 1;

        int[,] parent = new int[n + 1, k];
        int[] level = new int[n + 1];

        DFS(1, 0);

        for (int i = 1; i < k; i++)
        {
            for (int node = 1; node <= n; node++)
            {
                if (parent[node, i - 1] != 0)
                {
                    parent[node, i] = parent[parent[node, i - 1], i - 1];
                }
            }
        }

        int m = int.Parse(sr.ReadLine());
        for (int q = 0; q < m; q++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            (a, b) = level[a] >= level[b] ? (a, b) : (b, a);
            int diff = level[a] - level[b];
            for (int i = 0; i < k; i++)
            {
                bool bit = ((diff >> i) & 1) == 1;
                if (bit)
                {
                    a = parent[a, i];
                }
            }

            if (a == b)
            {
                sw.WriteLine(a);
                continue;
            }

            for (int i = k - 1; i >= 0; i--)
            {
                if (parent[a, i] != parent[b, i])
                {
                    a = parent[a, i];
                    b = parent[b, i];
                }
            }
            sw.WriteLine(parent[a, 0]);
        }

        void DFS(int node, int parentNode)
        {
            foreach (var child in tree[node])
            {
                if (child != parentNode)
                {
                    parent[child, 0] = node;
                    level[child] = level[node] + 1;
                    DFS(child, node);
                }
            }
        }
    }
}