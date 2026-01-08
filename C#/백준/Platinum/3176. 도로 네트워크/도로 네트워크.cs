#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int logN = (int)Math.Log(n, 2) + 1;

        int[,] sparse = new int[n + 1, logN];
        int[] level = new int[n + 1];
        (int min, int max)[,] dist = new (int, int)[n + 1, logN];

        List<(int node, int cost)>[] tree = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            tree[i] = new List<(int, int)>();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];

            tree[a].Add((b, cost));
            tree[b].Add((a, cost));
        }

        DFS(1, 0);

        for (int k = 1; k < logN; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                int moveNode = sparse[i, k - 1];
                sparse[i, k] = sparse[moveNode, k - 1];
                dist[i, k].min = Math.Min(dist[i, k - 1].min, dist[moveNode, k - 1].min);
                dist[i, k].max = Math.Max(dist[i, k - 1].max, dist[moveNode, k - 1].max);
            }
        }

        int m = int.Parse(sr.ReadLine());
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            (int min, int max) = LCA(a, b);
            sw.WriteLine($"{min} {max}");
        }

        void DFS(int node, int parent)
        {
            sparse[node, 0] = parent;
            level[node] = level[parent] + 1;

            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;

                dist[child.node, 0] = (child.cost, child.cost);
                DFS(child.node, node);
            }
        }

        (int, int) LCA(int a, int b)
        {
            (a, b) = level[a] < level[b] ? (b, a) : (a, b);

            int min = int.MaxValue;
            int max = int.MinValue;

            int diff = level[a] - level[b];
            for (int i = 0; i < logN; i++)
            {
                bool bit = ((diff >> i) & 1) == 1;
                if (bit)
                {
                    min = Math.Min(dist[a, i].min, min);
                    max = Math.Max(dist[a, i].max, max);
                    a = sparse[a, i];
                }
            }

            if (a == b)
            {
                return (min, max);
            }

            for (int i = logN - 1; i >= 0; i--)
            {
                if (sparse[a, i] != sparse[b, i])
                {
                    min = Math.Min(dist[a, i].min, min);
                    min = Math.Min(dist[b, i].min, min);
                    max = Math.Max(dist[a, i].max, max);
                    max = Math.Max(dist[b, i].max, max);

                    a = sparse[a, i];
                    b = sparse[b, i];
                }
            }
            min = Math.Min(dist[a, 0].min, min);
            min = Math.Min(dist[b, 0].min, min);
            max = Math.Max(dist[a, 0].max, max);
            max = Math.Max(dist[b, 0].max, max);

            return (min, max);
        }
    }
}