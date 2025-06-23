#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[,] board = new int[n, n];
        int[,] distance = new int[n, n];
        for (int y = 0; y < n; y++)
        {
            string[] line = sr.ReadLine().Split();   
            for (int x = 0; x < n; x++)
            {
                board[x, y] = int.Parse(line[x]);
                distance[x,y] = int.MaxValue;
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        PriorityQueue<(int x, int y, int cost), int> queue = new();
        queue.Enqueue((0, 0, 0), 0);
        distance[0,0] = 0;
        while (queue.Count > 0)
        {
            (int x, int y, int cost) = queue.Dequeue();
            if (x == n - 1 && y == n - 1)
            {
                sw.Write(cost);
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= n || py >= n)
                {
                    continue;
                }
                int curnode = Math.Abs(board[px, py] - board[x, y]);
                int curcost = Math.Max(cost, curnode);
                if (curcost < distance[px, py])
                {
                    distance[px, py] = curcost;
                    queue.Enqueue((px, py, curcost), curcost);
                }
            }
        }
    }
}
