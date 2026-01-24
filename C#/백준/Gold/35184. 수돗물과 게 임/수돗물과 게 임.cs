#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int t = int.Parse(input[2]);

        char[,] board = new char[m, n];
        HashSet<(int x, int y)> hash = new();
        int startX = -1;
        int startY = -1;

        int[,,] visited = new int[m, n, 4];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
                if ('0' <= line[x] && line[x] <= '3')
                {
                    startX = x;
                    startY = y;
                }
                else if (line[x] == 'S')
                {
                    hash.Add((x, y));
                }

                for (int i = 0; i < 4; i++)
                    visited[x, y, i] = int.MaxValue;
            }
        }

        PriorityQueue<(int x, int y, int dir, int time), int> queue = new();
        int startDir = board[startX, startY] - '0';

        queue.Enqueue((startX, startY, startDir, 0), 0);
        visited[startX, startY, startDir] = 0;

        int[] dx = new int[] { 0, -1, 0, 1 };
        int[] dy = new int[] { -1, 0, 1, 0 };

        while (queue.Count > 0)
        {
            (int x, int y, int dir, int time) = queue.Dequeue();

            if (hash.Contains((x, y)))
            {
                sw.Write(time);
                return;
            }

            if (board[x, y] == 'T')
            {
                int curDir = (dir + 1) % 4;
                int px = x + dx[curDir];
                int py = y + dy[curDir];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (time < visited[px, py, curDir])
                {
                    visited[px, py, curDir] = time;
                    queue.Enqueue((px, py, curDir, time), time);
                }
                continue;
            }

            for (int i = 1; i < 4; i++)
            {
                int curDir = (dir + i) % 4;

                int curTime = time + t * i;
                if (curTime < visited[x, y, curDir])
                {
                    visited[x, y, curDir] = curTime;
                    queue.Enqueue((x, y, curDir, curTime), curTime);
                }
            }

            for (int i = 1; i <= 3; i += 2)
            {
                int moveDir = (dir + i) % 4;

                int px = x + dx[moveDir];
                int py = y + dy[moveDir];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (time + 1 < visited[px, py, dir])
                {
                    visited[px, py, dir] = time + 1;
                    queue.Enqueue((px, py, dir, time + 1), time + 1);
                }
            }
        }

        sw.Write(-1);
    }
}