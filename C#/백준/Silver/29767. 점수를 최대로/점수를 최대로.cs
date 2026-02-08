#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long[] dp = new long[n];
        dp[0] = arr[0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = dp[i - 1] + arr[i];
        }

        Array.Sort(dp, (a,b) => b.CompareTo(a));

        long value = 0;
        for (int i = 0; i < k; i++)
        {
            value += dp[i];
        }
        sw.Write(value);

    }
}