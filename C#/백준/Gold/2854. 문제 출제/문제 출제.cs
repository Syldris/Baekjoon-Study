#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 65535));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 65535));

        int n = int.Parse(sr.ReadLine());
        int[] arr1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] arr2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        const int mod = 1000000007;
        long[,] dp = new long[n, 3];
        dp[0, 0] = arr1[0];
        dp[0, 1] = arr2[0];

        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = ((dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2]) * arr1[i]) % mod;

            if (i != n - 1)
                dp[i, 1] = ((dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2]) * arr2[i]) % mod;

            dp[i, 2] = ((dp[i - 1, 0] + dp[i - 1, 2]) * arr2[i - 1] + dp[i - 1, 1] * (arr2[i - 1] - 1)) % mod;
        }
        sw.Write((dp[n - 1, 0] + dp[n - 1, 2]) % mod);
    }
}