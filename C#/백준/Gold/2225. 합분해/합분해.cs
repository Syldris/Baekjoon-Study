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
        
        for (int i = 0; i <= n; i++)
        {
            dp[i, 1] = 1;
        }

        for (int j = 2; j <= k; j++)
        {
            for (int i = 1; i <= n; i++)
            {
                int value = 0;
                for (int v = i; v > 0; v--)
                {
                    value = (value + dp[v, j - 1]) % 1000000000;
                }
                dp[i, j] = value + 1;
            }
        }

        sw.Write(dp[n, k]);
    }
}