#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 17);

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

        long[] size = new long[n + 1];
        long[] bus = new long[n + 1];

        DFS(1, 0);

        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine(bus[i] + n - 1);
        }

        void DFS(int node, int parent)
        {
            size[node] = 1;
            foreach (var child in tree[node])
            {
                if (child != parent)
                {
                    DFS(child, node);
                    size[node] += size[child];
                }
            }

            bus[parent] += (n - size[node]) * size[node];

            bus[node] += (n - size[node]) * size[node];
        }
    }
}