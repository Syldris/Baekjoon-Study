#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 65535));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 65535));

        int n = int.Parse(sr.ReadLine());
        int[,] dp = new int[n + 1, 11];
        const int mod = 1000000000;
        for (int i = 0; i <= 9; i++)
        {
            dp[1, i] = 1;
        }

        for (int i = 2; i <= n; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (j == 0)
                {
                    dp[i, j] = dp[i - 1, j + 1] % mod;
                    continue;
                }
                dp[i, j] = (dp[i - 1, j - 1] + dp[i - 1, j + 1]) % mod; 
            }
        }

        int result = 0;
        for (int i = 1; i <= 9; i++)
        {
            result = (result + dp[n, i]) % mod;
        }
        sw.Write(result);
    }
}