#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int a = int.Parse(sr.ReadLine());
        List<(int node, int cost)>[] treeA = new List<(int node, int cost)>[a + 1];
        for (int i = 1; i <= a; i++)
            treeA[i] = new();

        for (int i = 1; i < a; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int from = line[0];
            int to = line[1];
            int cost = line[2];

            treeA[from].Add((to, cost));
            treeA[to].Add((from, cost));
        }

        int b = int.Parse(sr.ReadLine());
        List<(int node, int cost)>[] treeB = new List<(int node, int cost)>[b + 1];
        for (int i = 1; i <= b; i++)
            treeB[i] = new();

        for (int i = 1; i < b; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int from = line[0];
            int to = line[1];
            int cost = line[2];

            treeB[from].Add((to, cost));
            treeB[to].Add((from, cost));
        }

        long[] sizeA = new long[a + 1];
        long[] sizeB = new long[b + 1];

        int senterA = 1;
        int senterB = 1;
        long distA = 0;
        long distB = 0;

        DFS(1, -1, 0, sizeA, treeA, ref distA);
        DFS(1, -1, 0, sizeB, treeB, ref distB);

        RerooTing(1, -1, distA, sizeA, treeA, ref distA, ref senterA);
        RerooTing(1, -1, distB, sizeB, treeB, ref distB, ref senterB);

        sw.WriteLine($"{senterA} {senterB}");
        sw.WriteLine(distA * b + distB * a + (long)a * b);

        void DFS(int node, int parent, long value, long[] size, List<(int node, int cost)>[] tree, ref long dist)
        {
            size[node] = 1;
            dist += value;

            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;

                DFS(child.node, node, child.cost + value, size, tree, ref dist);

                size[node] += size[child.node];
            }
        }

        void RerooTing(int node, int parent, long value, long[] size, List<(int node, int cost)>[] tree, ref long dist, ref int senter)
        {
            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;

                long diff = size[1] - size[child.node];

                long curValue = value - (size[child.node] * child.cost) + diff * child.cost;

                if (curValue < dist)
                {
                    dist = curValue;
                    senter = child.node;
                }
                RerooTing(child.node, node, curValue, size, tree, ref dist, ref senter);
            }
        }
    }
}