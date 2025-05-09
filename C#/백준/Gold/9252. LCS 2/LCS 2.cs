using System.Text;
public class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        int[,] dp = new int[a.Length + 1, b.Length + 1];

        int x = a.Length;
        int y = b.Length;

        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= x; i++)
        {
            char achar = a[i - 1];
            for (int j = 1; j <= y; j++)
            {
                char bchar = b[j - 1];
                if (achar == bchar)
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        Console.WriteLine(dp[x,y]);

        while (x > 0 && y > 0)
        {
            if (a[x - 1] == b[y - 1])
            {
                sb.Append(a[x - 1]);
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
                x--;
            else
                y--;
        }

        char[] result = sb.ToString().ToArray();
        Array.Reverse(result);
        Console.WriteLine(new String(result));
    }
}
