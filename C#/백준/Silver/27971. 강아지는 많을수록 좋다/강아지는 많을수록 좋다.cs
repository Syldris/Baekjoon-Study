#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int a = int.Parse(input[2]);
        int b = int.Parse(input[3]);

        bool[] delete = new bool[n + 1];
        for (int t = 0; t < m; t++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            for (int i = start; i <= end; i++)
            {
                delete[i] = true;
            }
        }
        int[] dp = new int[n + 1];

        Queue<int> queue = new Queue<int>();
        if (!delete[a])
        {
            queue.Enqueue(a);
            dp[a] = 1;
        }
        if (!delete[b])
        {
            queue.Enqueue(b);
            dp[b] = 1;
        }

        while (queue.Count > 0)
        {
            int value = queue.Dequeue();

            int rootA = value + a;
            int rootB = value + b;
            if (rootA <= n && !delete[rootA] && dp[rootA] == 0)
            {
                dp[rootA] = dp[value] + 1;
                queue.Enqueue(rootA);
            }
            if (rootB <= n && !delete[rootB] && dp[rootB] == 0)
            {
                dp[rootB] = dp[value] + 1;
                queue.Enqueue(rootB);
            }
        }

        sw.Write(dp[n] == 0 ? -1 : dp[n]);
    }
}