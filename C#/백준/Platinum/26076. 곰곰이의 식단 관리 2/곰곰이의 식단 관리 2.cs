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
        int[,] visited = new int[m, n];
        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
                visited[x, y] = int.MaxValue;
            }
        }

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        Queue<(int x, int y, int time)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((0, 0, 0));
        visited[0, 0] = 0;

        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (board[px, py] == 1)
                    continue;

                int curTime = time + 1;

                if (curTime < visited[px, py])
                {
                    visited[px, py] = curTime;
                    queue.Enqueue((px, py, curTime));
                }
            }
        }

        if (visited[m - 1, n - 1] == int.MaxValue)
        {
            sw.Write(0);
            return;
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                visited[x, y] = int.MaxValue;
            }
        }


        int[] rx = new int[] { 1, 1, 1, 0, 0, -1, -1, -1 };
        int[] ry = new int[] { 1, 0, -1, 1, -1, 1, 0, -1 };

        for (int i = 1; i < n; i++)
        {
            int value = board[0, i] == 0 ? 1 : 0;
            if (Dijkstra(0, i, value))
            {
                sw.Write(1);
                return;
            }
        }

        for (int i = 0; i < m - 1; i++)
        {
            int value = board[i, n - 1] == 0 ? 1 : 0;
            if (Dijkstra(i, n - 1, value))
            {
                sw.Write(1);
                return;
            }
        }

        sw.Write(2);

        bool Dijkstra(int startX, int startY, int startValue)
        {
            Queue<(int x, int y, int value)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((startX, startY, startValue));
            visited[startX, startY] = startValue;

            List<(int x, int y)> visitedList = new List<(int x, int y)>();
            visitedList.Add((startX, startY));

            while (queue.Count > 0)
            {
                (int x, int y, int value) = queue.Dequeue();
                if (x == m - 1 || y == 0)
                {
                    DijkstarClear(visitedList);
                    return true;
                }

                for (int i = 0; i < 8; i++)
                {
                    int px = x + rx[i];
                    int py = y + ry[i];

                    if (px < 0 || py < 0 || px >= m || py >= n)
                        continue;

                    int curValue = value;
                    if (board[px, py] == 0)
                        curValue++;

                    if (curValue < visited[px, py] && curValue <= 1)
                    {
                        visited[px, py] = curValue;
                        visitedList.Add((px, py));
                        queue.Enqueue((px, py, curValue));
                    }
                }

            }
            DijkstarClear(visitedList);
            return false;
        }

        void DijkstarClear(List<(int x, int y)> list)
        {
            foreach ((int x, int y) in list)
            {
                visited[x, y] = int.MaxValue;
            }
        }
    }
}