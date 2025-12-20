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

        const int max = 200000;
        Array.Fill(dp, max);
        dp[a] = 1;
        dp[b] = 1;


        for (int i = 0; i <= n; i++)
        {
            if (i >= a && !delete[i - a] && dp[i - a] != max)
            {
                dp[i] = Math.Min(dp[i - a] + 1, dp[i]);
            }
            if (i >= b && !delete[i - b] && dp[i - b] != max)
            {
                dp[i] = Math.Min(dp[i - b] + 1, dp[i]);
            }
        }
        sw.Write(dp[n] == max ? -1 : dp[n]);
    }
}