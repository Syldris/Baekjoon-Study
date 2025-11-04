    #nullable disable
    using System;
    using System.Text;
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            int[] dp = new int[n * 3 + 1];
            int[] prev = new int[n * 3 + 1];
            const int max = 1000000;

            Array.Fill(dp, max);
            dp[1] = 0;

            for (int i = 1; i <= n; i++)
            {
                if (dp[i] > dp[i - 1] + 1)
                {
                    dp[i] = dp[i - 1] + 1;
                    prev[i] = i - 1;
                }
                if (dp[i * 2] > dp[i] + 1)
                {
                    dp[i * 2] = dp[i] + 1;
                    prev[i * 2] = i;
                }
                if (dp[i * 3] > dp[i] + 1)
                {
                    dp[i * 3] = dp[i] + 1;
                    prev[i * 3] = i;
                }
            }

            List<int> list = new List<int>();
            for (int i = n; i != 1; i = prev[i])
            {
                list.Add(i);
            }
            list.Add(1);
            sw.WriteLine(dp[n]);
            sw.WriteLine(String.Join(' ', list));
        }
    }