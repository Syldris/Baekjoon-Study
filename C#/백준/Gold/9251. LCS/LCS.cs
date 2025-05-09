using System.Text;
public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        int[,] dp = new int[a.Length + 1, b.Length + 1];

        for (int i = 1; i <= a.Length; i++)
        {
            char achar = a[i - 1];
            for (int j = 1; j <= b.Length; j++)
            {
                char bchar = b[j - 1];
                if (achar == bchar)
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        Console.WriteLine(dp[a.Length,b.Length]);
    }
}
