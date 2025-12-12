#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        List<(int node, int cost)>[] tree = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<(int, int)>();
        }

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int cost = int.Parse(line[2]);

            tree[a].Add((b, cost));
            tree[b].Add((a, cost));
        }

        long rootDistance = 0;
        int[] subtree = new int[n + 1];

        DFS(1, -1, 0);
        long[] nodeDistance = new long[n + 1];
        nodeDistance[1] = rootDistance;

        Rerooting(1, -1, rootDistance);
        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine(nodeDistance[i]);
        }

        void DFS(int node, int parent, int cost)
        {
            subtree[node] = 1;
            rootDistance += cost;

            foreach (var child in tree[node])
            {
                if (child.node == parent)
                    continue;
                DFS(child.node, node, cost + child.cost);
                subtree[node] += subtree[child.node];
            }
        }

        void Rerooting(int node, int parent, long distance)
        {
            foreach (var child in tree[node])
            {
                if (child.node == parent)
                    continue;

                long value = distance;
                value -= (long)subtree[child.node] * child.cost;
                value += (subtree[1] - subtree[child.node]) * child.cost;
                nodeDistance[child.node] = value;

                Rerooting(child.node, node, value);
            }
        }
    }
}