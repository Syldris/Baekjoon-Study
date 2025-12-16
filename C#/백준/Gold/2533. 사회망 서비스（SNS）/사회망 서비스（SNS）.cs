#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[,] dp = new int[n + 1, 2];

        List<int>[] tree = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<int>();
        }
        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            tree[a].Add(b);
            tree[b].Add(a);
        }


        DFS(1, -1);

        sw.Write(Math.Min(dp[1, 0], dp[1, 1]));

        void DFS(int node, int parent)
        {
            dp[node, 0] = 0;
            dp[node, 1] = 1;
            foreach (var child in tree[node])
            {
                if (child == parent)
                    continue;
                DFS(child, node);
                dp[node, 0] += dp[child, 1];
                dp[node, 1] += Math.Min(dp[child, 0], dp[child, 1]);
            }
        }
    }
}