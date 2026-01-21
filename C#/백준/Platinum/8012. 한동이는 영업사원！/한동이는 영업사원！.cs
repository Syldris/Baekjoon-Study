#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int logN = 30;

        int[,] sparse = new int[n + 1, logN];
        int[] level = new int[n + 1];
        List<int>[] tree = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            tree[i] = new List<int>();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            tree[a].Add(b);
            tree[b].Add(a);
        }

        DFS(1, -1);

        for (int k = 1; k < logN; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                if (sparse[i, k - 1] != 0)
                    sparse[i, k] = sparse[sparse[i, k - 1], k - 1];
            }
        }

        int pos = 1;
        int result = 0;

        int m = int.Parse(sr.ReadLine());

        for (int i = 0; i < m; i++)
        {
            int nextPos = int.Parse(sr.ReadLine());
            int value = LCA(pos, nextPos);
            result += value;
            pos = nextPos;
        }

        sw.Write(result);

        void DFS(int node, int parent)
        {
            foreach (var child in tree[node])
            {
                if (child == parent) continue;
                sparse[child, 0] = node;
                level[child] = level[node] + 1;
                DFS(child, node);
            }
        }

        int LCA(int a, int b)
        {
            (a, b) = level[a] > level[b] ? (a, b) : (b, a);

            int value = 0;
            int diff = level[a] - level[b];

            for (int i = 0; i < logN; i++)
            {
                bool bit = ((diff >> i) & 1) == 1;
                if (bit)
                {
                    a = sparse[a, i];
                    value += 1 << i;
                }
            }

            if (a == b)
            {
                return value;
            }

            for (int i = logN - 1; i >= 0; i--)
            {
                if (sparse[a, i] != sparse[b, i])
                {
                    a = sparse[a, i];
                    b = sparse[b, i];
                    value += (1 << i) * 2;
                }
            }

            return value + 2;
        }
    }
}