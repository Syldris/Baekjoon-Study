#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);

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
        int result = 0;
        for (int i = a; i <= b; i++)
        {
            int value = 0;
            int n = i;
            while (n != dp[n])
            {
                n /= dp[n];
                value++;
            }
            value++;

            if (dp[value] == value)
            {
                result++;
            }
        }
        sw.Write(result);
    }
}