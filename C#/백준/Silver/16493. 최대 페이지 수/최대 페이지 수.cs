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

        int[] dp = new int[n + 1];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int day = int.Parse(line[0]);
            int money = int.Parse(line[1]);

            for (int j = n; j >= day; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - day] + money);
            }
        }

        sw.Write(dp[n]);

    }
}