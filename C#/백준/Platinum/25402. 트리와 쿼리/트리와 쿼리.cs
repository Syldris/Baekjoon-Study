#nullable disable
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        List<int>[] tree = new List<int>[n + 1];
        int[] parent = new int[n + 1];
        int[] size = new int[n + 1];
        int[] nodeParent = new int[n + 1];

        bool[] selected = new bool[n + 1];
        bool[] visited = new bool[n + 1];

        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<int>();
            parent[i] = i;
            size[i] = 1;
        }

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            tree[a].Add(b);
            tree[b].Add(a);
        }

        DFS(1, 0);


        int query = int.Parse(sr.ReadLine());
        for (int q = 0; q < query; q++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int k = line[0];

            for (int i = 1; i <= k; i++)
            {
                int node = line[i];
                selected[node] = true;
            }

            for (int i = 1; i <= k; i++)
            {
                int node = line[i];
                int p = nodeParent[node];
                if (selected[p])
                {
                    Union(node, nodeParent[node]);
                }
            }

            long result = 0;

            for (int i = 1; i <= k; i++)
            {
                int node = line[i];
                if (node == parent[node])
                {
                    long value = size[node];
                    result += value * (value - 1) / 2;
                }
            }

            for (int i = 1; i <= k; i++)
            {
                int node = line[i];

                parent[node] = node; // 초기화
                size[node] = 1;
                selected[node] = false;
                visited[node]= false;
            }
            sw.WriteLine(result);
        }

        void DFS(int node, int parent)
        {
            nodeParent[node] = parent;
            foreach (var child in tree[node])
            {
                if (child == parent) continue;

                DFS(child, node);
            }
        }

        int Find(int x)
        {
            while (x != parent[x])
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }
            return parent[x];
        }

        void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                if (size[rootA] >= size[rootB])
                {
                    parent[rootB] = rootA;
                    size[rootA] += size[rootB];
                }
                else
                {
                    parent[rootA] = rootB;
                    size[rootB] += size[rootA];
                }
            }
        }
    }
}