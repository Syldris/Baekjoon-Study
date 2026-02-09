#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] board = new int[m, n];
        long[,] visited = new long[m, n];

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
                visited[x, y] = long.MaxValue;
            }
        }

        PriorityQueue<(int x, int y, long cost), long> queue = new();

        for (int i = 1; i < n; i++)
        {
            if (board[0, i] == -1) continue;
            long cost = board[0, i] == -2 ? 0 : board[0, i];

            queue.Enqueue((0, i, cost), cost);
            visited[0, i] = cost;
        }

        for (int i = 1; i < m - 1; i++)
        {
            if (board[i, n - 1] == -1) continue;
            long cost = board[i, n - 1] == -2 ? 0 : board[i, n - 1];

            queue.Enqueue((i, n - 1, cost), cost);
            visited[i, n - 1] = cost;
        }

        int[] dx = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        while (queue.Count > 0)
        {
            (int x, int y, long cost) = queue.Dequeue();
            if (x == m - 1 || y == 0)
            {
                sw.Write(cost);
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (board[px, py] == -1)
                    continue;

                long curCost = board[px, py] == -2 ? cost : cost + board[px, py];
                if (curCost < visited[px, py])
                {
                    visited[px, py] = curCost;
                    queue.Enqueue((px, py, curCost), curCost);
                }
            }
        }

        sw.Write(-1);
    }
}