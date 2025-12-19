#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long n = long.Parse(sr.ReadLine());
        int[] dp = new int[1500000];
        dp[1] = 1;
        for (int i = 2; i < 1500000; i++)
        {
            dp[i] = (dp[i - 1] + dp[i - 2]) % 1000000;
        }

        sw.WriteLine(dp[n % 1500000]);
    }
}