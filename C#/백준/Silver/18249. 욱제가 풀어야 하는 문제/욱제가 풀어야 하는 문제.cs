#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());
        const int mod = 1000000007;
        int[] dp = new int[191230];
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i < 191230; i++)
        {
            dp[i] = ((dp[i - 1] + dp[i - 2])) % mod;
        }

        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            sw.WriteLine(dp[n]);
        }
    }
}