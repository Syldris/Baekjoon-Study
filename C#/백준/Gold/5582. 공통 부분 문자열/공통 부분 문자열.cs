public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        int alen = a.Length;
        int blen = b.Length;

        int value = 0;

        int[,] dp = new int[alen + 1, blen + 1];

        for (int i = 1; i <= alen; i++)
        {
            for (int j = 1; j <= blen; j++)
            {
                if (a[i-1] == b[j-1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                    value = Math.Max(value, dp[i, j]);
                }
            }
        }
        Console.WriteLine(value);
    }
}
