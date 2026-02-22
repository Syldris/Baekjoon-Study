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
            List<int> list = new();
            while (n != dp[n])
            {
                list.Add(dp[n]);
                n /= dp[n];
            }

            list.Add(n);

            int prev = list[0];
            int count = 0;
            foreach (var item in list)
            {
                if (item != prev)
                {
                    sw.WriteLine($"{prev} {count}");
                    prev = item;
                    count = 0;
                }
                count++;
            }
            sw.WriteLine($"{prev} {count}");
        }
    }
}