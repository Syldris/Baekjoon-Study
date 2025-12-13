#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] dp = new int[1000001];
        dp[1] = 1;
        dp[2] = 1;
        for (int i = 3; i <= n; i++)
        {
            dp[i] = (dp[i - 1] + dp[i - 2]) % 1000000007;
        }
        sw.Write(dp[n]);
    }
}