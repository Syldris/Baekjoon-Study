#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int root = int.Parse(input[1]);
        int query = int.Parse(input[2]);

        List<int>[] tree = new List<int>[n + 1];
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<int>();
        }

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);

            tree[u].Add(v);
            tree[v].Add(u);
        }

        DFS(root, -1);

        for (int i = 0; i < query; i++)
        {
            int u = int.Parse(sr.ReadLine());
            sw.WriteLine(dp[u]);
        }

        void DFS(int node, int parent)
        {
            dp[node] = 1;
            foreach (var connect in tree[node])
            {
                if (connect != parent)
                {
                    DFS(connect, node);
                    dp[node] += dp[connect];
                }
            }
        }
    }
}