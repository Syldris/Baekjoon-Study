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
        int x = int.Parse(input[2]);

        int max = x * k;

        int[,] dp = new int[k + 1, max + 1]; //dp[power] = speed;
        for (int i = 0; i <= k; i++)
        {
            for (int j = 0; j <= max; j++)
            {
                dp[i, j] = -1;
            }
        }

        dp[0, 0] = 0;

        for (int i = 1; i <= n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int power = line[0];
            int speed = line[1];

            for (int j = k; j > 0; j--)
            {
                for (int v = max; v >= power; v--)
                {
                    if (dp[j - 1, v - power] == -1) continue;

                    dp[j, v] = dp[j - 1, v - power] + speed;
                }
            }
        }

        int result = 0;

        for (int i = 1; i <= max; i++)
        {
            result = Math.Max(i * dp[k, i], result);
        }

        sw.Write(result);
    }
}