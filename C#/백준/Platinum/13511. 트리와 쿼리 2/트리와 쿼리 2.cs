#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int logN = (int)Math.Log(n, 2) + 1;

        List<(int node, int cost)>[] tree = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            tree[i] = new();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];

            tree[a].Add((b, cost));
            tree[b].Add((a, cost));
        }

        int[,] sparse = new int[n + 1, logN];
        int[] level = new int[n + 1];
        long[] dist = new long[n + 1];

        DFS(1, -1);

        for (int k = 1; k < logN; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                sparse[i, k] = sparse[sparse[i, k - 1], k - 1];
            }
        }

        int m = int.Parse(sr.ReadLine());
        for (int q = 0; q < m; q++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int query = line[0];
            int a = line[1];
            int b = line[2];

            if (query == 1)
            {
                sw.WriteLine(dist[a] + dist[b] - dist[LCA(a, b)] * 2);
            }
            else
            {
                int value = line[3] - 1;

                int lca = LCA(a, b);
                if (a == lca)
                {
                    int diff = level[b] - level[a] - value;
                    for (int i = 0; i < logN; i++)
                    {
                        bool bit = ((diff >> i) & 1) == 1;

                        if (bit) b = sparse[b, i];
                    }
                    sw.WriteLine(b);
                }
                else if (value <= level[a] - level[lca])
                {
                    for (int i = 0; i < logN; i++)
                    {
                        bool bit = ((value >> i) & 1) == 1;

                        if (bit) a = sparse[a, i];
                    }
                    sw.WriteLine(a);
                }
                else
                {
                    value -= level[a] - level[lca];

                    int diff = level[b] - level[lca] - value;

                    for (int i = 0; i < logN; i++)
                    {
                        bool bit = ((diff >> i) & 1) == 1;

                        if (bit) b = sparse[b, i];
                    }
                    sw.WriteLine(b);
                }
            }
        }

        void DFS(int node, int parent)
        {
            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;

                sparse[child.node, 0] = node;
                level[child.node] = level[node] + 1;
                dist[child.node] = dist[node] + child.cost;

                DFS(child.node, node);
            }
        }

        int LCA(int a, int b)
        {
            (a, b) = level[a] < level[b] ? (b, a) : (a, b);

            int diff = level[a] - level[b];

            for (int i = 0; i < logN; i++)
            {
                bool bit = ((diff >> i) & 1) == 1;

                if (bit) a = sparse[a, i];
            }

            if (a == b)
                return a;

            for (int i = logN - 1; i >= 0; i--)
            {
                if (sparse[a, i] != sparse[b, i])
                {
                    a = sparse[a, i];
                    b = sparse[b, i];
                }
            }
            return sparse[a, 0];
        }
    }
}