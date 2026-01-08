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
        int[,] dist = new int[n + 1, logN];

        int[] ants = new int[n];

        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < n; i++)
        {
            ants[i] = int.Parse(sr.ReadLine());
        }

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];
            graph[a].Add((b, cost));
            graph[b].Add((a, cost));
        }

        DFS(1, 0);

        for (int k = 1; k < logN; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                int midNode = sparse[i, k - 1];
                sparse[i, k] = sparse[midNode, k - 1];
                dist[i, k] = dist[i, k - 1] + dist[midNode, k - 1];
            }
        }

        for (int i = 1; i <= n; i++)
        {
            int pos = i;
            int power = ants[i - 1];

            for (int k = logN - 1; k >= 0; k--)
            {
                if (power >= dist[pos, k] && sparse[pos, k] != 0)
                {
                    power -= dist[pos, k];
                    pos = sparse[pos, k];
                }
            }

            sw.WriteLine(pos);
        }


        void DFS(int node, int parent)
        {
            foreach (var child in graph[node])
            {
                if (child.node == parent) continue;

                sparse[child.node, 0] = node;
                dist[child.node, 0] = child.cost;

                DFS(child.node, node);
            }
        }
    }
}