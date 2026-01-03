#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int logN = (int)Math.Floor(Math.Log(n, 2)) + 1;

        List<(int node, int cost)>[] tree = new List<(int node, int cost)>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<(int node, int cost)>();
        }

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];

            tree[a].Add((b, cost));
            tree[b].Add((a, cost));
        }

        int[] dist = new int[n + 1];
        int[] level = new int[n + 1];
        int[,] parent = new int[n + 1, logN];

        DFS(1, 0);

        for (int k = 1; k < logN; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                parent[i, k] = parent[parent[i, k - 1], k - 1];
            }
        }

        int m = int.Parse(sr.ReadLine());
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            sw.WriteLine(dist[a] + dist[b] - dist[LCA(a, b)] * 2);
        }

        void DFS(int node, int parentNode)
        {
            foreach (var child in tree[node])
            {
                if (child.node == parentNode)
                    continue;

                parent[child.node, 0] = node;
                level[child.node] = level[node] + 1;
                dist[child.node] = dist[node] + child.cost;

                DFS(child.node, node);
            }
        }

        int LCA(int a, int b)
        {
            (a, b) = level[a] > level[b] ? (a, b) : (b, a);
            int diff = level[a] - level[b];

            for (int i = 0; i < logN; i++)
            {
                bool bit = ((diff >> i) & 1) == 1;
                if (bit)
                {
                    a = parent[a, i];
                }
            }

            if (a == b)
            {
                return a;
            }

            for (int i = logN - 1; i >= 0; i--)
            {
                if (parent[a, i] != parent[b, i])
                {
                    a = parent[a, i];
                    b = parent[b, i];
                }
            }

            return parent[a, 0];
        }
    }
}