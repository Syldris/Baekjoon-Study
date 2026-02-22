#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        const int max = 100000;
        int[] dp = new int[max + 1];
        for (int i = 2; i <= max; i++)
        {
            if (dp[i] == 0)
            {
                for (int j = i; j <= max; j += i)
                {
                    if (dp[j] == 0)
                        dp[j] = i;
                }
            }
        }
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());

            int prev = dp[n];
            int count = 0;
            while (n != dp[n])
            {
                if (prev != dp[n]) // 전이랑 달라지면 바로 출력
                {
                    sw.WriteLine($"{prev} {count}");
                    prev = dp[n];
                    count = 0;
                }
                n /= dp[n];
                count++; // 해당 소인수 분해 횟수
            }

            if (prev != n)
            {
                sw.WriteLine($"{prev} {count}");
                prev = dp[n];
                count = 0;
            }
            count++;

            sw.WriteLine($"{prev} {count}");
        }
    }
}