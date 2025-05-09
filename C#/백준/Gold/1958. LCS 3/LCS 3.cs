public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string c = Console.ReadLine();
        int alen = a.Length;
        int blen = b.Length;
        int clen = c.Length;

        int[,,] dp = new int[alen + 1, blen + 1, clen + 1];

        for (int i = 1; i <= alen; i++)
        {
            char achar = a[i-1];
            for (int j = 1; j <= blen; j++)
            {
                char bchar = b[j-1];
                for(int k = 1; k <= clen; k++)
                {
                    char cchar = c[k-1];
                    if (achar == bchar && bchar == cchar)
                    {
                        dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                    }
                    else
                    {
                        dp[i, j, k] = Math.Max(Math.Max(dp[i - 1, j, k], dp[i, j - 1, k]), dp[i, j, k - 1]);
                    }
                }
            }
        }
        Console.WriteLine(dp[alen, blen, clen]);
    }
}
