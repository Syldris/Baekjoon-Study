#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int startX = input[1] - 1;
        int startY = input[0] - 1;
        int endX = input[3] - 1;
        int endY = input[2] - 1;

        int[,] boardA = new int[n, n];
        int[,] boardB = new int[n, n];
        long[,,] visited = new long[n, n, 4];

        (int x, int y, int dir)[,,] prev = new (int x, int y, int dir)[n, n, 4];

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                boardA[x, y] = line[x];
                for (int d = 0; d < 4; d++)
                {
                    visited[x, y, d] = long.MaxValue;
                    prev[x, y, d] = (-1, -1, -1);
                }
            }
        }
        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                boardB[x, y] = line[x];
            }
        }

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        PriorityQueue<(int x, int y, int dir, long value), long> queue = new();
        for (int dir = 0; dir < 4; dir++)
        {
            int value = boardA[endX, endY];
            visited[endX, endY, dir] = value;

            queue.Enqueue((endX, endY, dir, value), value);
        }

        List<char> result = new List<char>();

        while (queue.Count > 0)
        {
            (int x, int y, int dir, long value) = queue.Dequeue();
            if (x == startX && y == startY)
            {
                TrackBack(x, y, dir);

                sw.WriteLine(result.Count);
                foreach (var node in result)
                {
                    sw.Write(node);
                }

                return;
            }

            int px = x + dx[dir];
            int py = y + dy[dir];

            if (px < 0 || py < 0 || px >= n || py >= n)
                continue;

            for (int i = 0; i < 4; i++)
            {
                long curValue = value;
                if (dir != i)
                {
                    if (curValue > long.MaxValue / boardB[px, py])
                    {
                        continue;
                    }
                    curValue *= boardB[px, py];
                }

                if (curValue > long.MaxValue - boardA[px, py])
                {
                    continue;
                }

                curValue += boardA[px, py];

                if (curValue < visited[px, py, i])
                {
                    prev[px, py, i] = (x, y, dir);
                    visited[px, py, i] = curValue;
                    queue.Enqueue((px, py, i, curValue), curValue);
                }
            }
        }

        void TrackBack(int x, int y, int dir)
        {
            (int nextX, int nextY, int nextDir) = prev[x, y, dir];
            if (nextX == -1 && nextY == -1 && nextDir == -1)
            {
                return;
            }

            char c = nextDir switch
            {
                0 => 'R',
                1 => 'L',
                2 => 'D',
                3 => 'U',
            };

            result.Add(c);
            TrackBack(nextX, nextY, nextDir);
        }
    }
}