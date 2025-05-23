using System;
using System.Numerics;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int[,] board = new int[m, n];
        int[,] dp = new int[m, n];
        for (int y = 0; y < n; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < m; x++)
            {
                board[x,y] = line[x];
                dp[x, y] = -1;
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        int DFS(int x, int y)
        {
            if(x == m-1 && y == n-1)
            {
                return 1;
            }

            if(dp[x,y] != -1) 
                return dp[x,y];

            dp[x, y] = 0;

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if(px <  0 || py < 0 || px >= m || py >= n)
                    continue;

                if (board[px,py] < board[x,y])
                {
                    dp[x, y] += DFS(px, py);
                }    
            }
            return dp[x,y];
        }
        sw.Write(DFS(0, 0));
    }
}