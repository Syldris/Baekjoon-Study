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

        bool[,] board = new bool[m, n];
        int[,] visited = new int[m, n];
        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x] == 0 ? true : false;
                visited[x, y] = int.MaxValue;
            }
        }

        int[,] sum = new int[m + 1, n + 1];
        for (int y = 1; y <= n; y++)
        {
            for (int x = 1; x <= m; x++)
            {
                int value = board[x - 1, y - 1] ? 0 : 1;
                sum[x, y] = sum[x - 1, y] + sum[x, y - 1] - sum[x - 1, y - 1] + value;
            }
        }

        string[] input2 = sr.ReadLine().Split();
        int h = int.Parse(input2[0]);
        int w = int.Parse(input2[1]);

        int startY = int.Parse(input2[2]) - 1;
        int startX = int.Parse(input2[3]) - 1;
        int endY = int.Parse(input2[4]) - 1;
        int endX = int.Parse(input2[5]) - 1;

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };


        Queue<(int x, int y, int value)> queue = new();

        queue.Enqueue((startX, startY, 0));
        while (queue.Count > 0)
        {
            (int x, int y, int value) = queue.Dequeue();

            if (x == endX && y == endY)
            {
                sw.Write(value);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (!board[px, py])
                    continue;

                if (value >= visited[px, py])
                    continue;

                if (Check(px, py))
                {
                    visited[px, py] = value;
                    queue.Enqueue((px, py, value + 1));
                }
            }
        }

        sw.Write(-1);

        bool Check(int x, int y)
        {
            int px = x + w - 1;
            int py = y + h - 1;

            if (px >= m || py >= n) return false;

            int value = sum[px + 1, py + 1] - sum[x, py + 1] - sum[px + 1, y] + sum[x, y];

            return value == 0;
        }
    }
}