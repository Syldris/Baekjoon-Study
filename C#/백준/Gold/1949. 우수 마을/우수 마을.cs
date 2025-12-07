#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        List<int>[] tree = new List<int>[n + 1];
        int[,] dp = new int[n + 1, 2];
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

        sw.WriteLine(Math.Max(dp[1, 0], dp[1, 1]));

        void DFS(int node, int parent)
        {
            dp[node, 0] = 0;
            dp[node, 1] = arr[node - 1];

            foreach (var child in tree[node])
            {
                if (child != parent)
                {
                    DFS(child, node);
                    dp[node, 0] += Math.Max(dp[child, 1], dp[child, 0]);
                    dp[node, 1] += dp[child, 0];
                }
            }
        }
    }
}