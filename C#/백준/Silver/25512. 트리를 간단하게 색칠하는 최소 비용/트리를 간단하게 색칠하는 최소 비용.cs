#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        List<int>[] tree = new List<int>[n];
        for(int i = 0; i < n; i++)
            tree[i] = new List<int>();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];

            tree[a].Add(b);
        }

        long[,] dp = new long[n, 2];

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int white = line[0];
            int black = line[1];

            dp[i,0] = white;
            dp[i,1] = black;
        }

        DFS(0);

        sw.Write(Math.Min(dp[0, 0], dp[0, 1]));

        void DFS(int node)
        {
            foreach (var child in tree[node])
            {
                DFS(child);
                dp[node, 0] += dp[child, 1];
                dp[node, 1] += dp[child, 0];
            }
        }
    }
}