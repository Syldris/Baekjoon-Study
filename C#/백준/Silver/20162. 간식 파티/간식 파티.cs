#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        (int value, int num)[] dp = new (int, int)[n];

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(sr.ReadLine());
            int max = 0;
            for (int j = 0; j < i; j++)
            {
                if (dp[j].num < value)
                {
                    max = Math.Max(dp[j].value, max);
                }
            }

            dp[i] = (value + max, value);
        }

        sw.Write(dp.Max().value);
    }
}