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

        int[] parent = new int[n + 1];
        int[] level = new int[n + 1];

        DFS(1, -1);
        int m = int.Parse(sr.ReadLine());
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            (a, b) = level[a] >= level[b] ? (a, b) : (b, a);
            while (level[a] != level[b])
            {
                a = parent[a];
            }

            int lev = level[a];
            while (a != b && lev-- > 0)
            {
                a = parent[a];
                b = parent[b];
            }
            sw.WriteLine(a);
        }

        void DFS(int node, int parentNode)
        {
            foreach (var child in tree[node])
            {
                if (child != parentNode)
                {
                    parent[child] = node;
                    level[child] = level[node] + 1;
                    DFS(child, node);
                }
            }
        }
    }
}