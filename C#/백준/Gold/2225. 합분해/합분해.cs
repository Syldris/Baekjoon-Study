#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[,] dp = new int[n + 1, k + 1];
        
        for (int j = 1; j <= k; j++)
        {
            dp[0, j] = 1;
        }

        for (int j = 1; j <= k; j++)
        {
            for (int i = 1; i <= n; i++)
            {
                dp[i, j] = (dp[i, j - 1] + dp[i - 1, j]) % 1000000000;
            }
        }

        sw.Write(dp[n, k]);
    }
}