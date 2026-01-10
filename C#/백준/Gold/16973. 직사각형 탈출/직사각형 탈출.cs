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

                bool check = i switch
                {
                    0 => CheckY(px, py),
                    1 => CheckY(px + w - 1, py),
                    2 => CheckX(px, py),
                    3 => CheckX(px, py + h - 1)
                };

                if (check)
                {
                    visited[px, py] = value;
                    queue.Enqueue((px, py, value + 1));
                }
            }
        }

        sw.Write(-1);

        bool CheckY(int x, int y)
        {
            if (x >= m) return false;

            for (int i = y; i < y + h; i++)
            {
                if (i >= n) return false;

                if (!board[x, i])
                {
                    return false;
                }
            }
            return true;
        }

        bool CheckX(int x, int y)
        {
            if (y >= n) return false;

            for (int i = x; i < x + w; i++)
            {
                if (i >= m) return false;

                if (!board[i, y])
                {
                    return false;
                }
            }
            return true;
        }
    }
}