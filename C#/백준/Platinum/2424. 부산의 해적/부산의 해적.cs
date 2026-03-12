#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        (int x, int y) playerStartPoint = (0, 0);
        (int x, int y) enemyStartPoint = (0, 0);

        char[,] board = new char[m, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
                if (board[x, y] == 'Y')
                {
                    playerStartPoint = (x, y);
                }
                else if (board[x, y] == 'V')
                {
                    enemyStartPoint = (x, y);
                }
            }
        }

        int[,] visited = new int[m, n];
        int[,] movePoint = new int[m, n];
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                visited[x, y] = int.MaxValue;
                movePoint[x, y] = int.MaxValue;
            }
        }

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        Queue<(int x, int y, int time)> queue = new();
        queue.Enqueue((enemyStartPoint.x, enemyStartPoint.y, 0));
        visited[enemyStartPoint.x, enemyStartPoint.y] = 0;

        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();

            if (time > visited[x, y]) continue;

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n || board[px, py] == 'I')
                    continue;

                int nextTime = time + 1;

                if (nextTime < visited[px, py])
                {
                    queue.Enqueue((px, py, nextTime));
                    visited[px, py] = nextTime;
                }
            }
        }

        List<int> list = new(Math.Max(n, m));

        for (int y = 0; y < n; y++) // 가로로 정리
        {
            int minValue = int.MaxValue;
            void BuildMovePoint()
            {
                foreach (var node in list)
                {
                    movePoint[node, y] = Math.Min(minValue, movePoint[node, y]);
                }
                list.Clear();
                minValue = int.MaxValue;
            }

            for (int x = 0; x < m; x++)
            {
                if (board[x, y] == 'I') //벽을 만나면 지금까지 있던 노드들에 대해 최솟값으로 갱신 (수직선상으로 0거리에 갈수있으니)
                {
                    BuildMovePoint();
                }
                else
                {
                    minValue = Math.Min(minValue, visited[x, y]);
                    list.Add(x);
                }
            }
            BuildMovePoint();
        }

        for (int x = 0; x < m; x++) // 세로로 정리
        {
            int minValue = int.MaxValue;
            void BuildMovePoint()
            {
                foreach (var node in list)
                {
                    movePoint[x, node] = Math.Min(minValue, movePoint[x, node]);
                }
                list.Clear();
                minValue = int.MaxValue;
            }

            for (int y = 0; y < n; y++)
            {
                if (board[x, y] == 'I') //벽을 만나면 지금까지 있던 노드들에 대해 최솟값으로 갱신 (수직선상으로 0거리에 갈수있으니)
                {
                    BuildMovePoint();
                }
                else
                {
                    minValue = Math.Min(minValue, visited[x, y]);
                    list.Add(y);
                }
            }
            BuildMovePoint();
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                visited[x, y] = int.MaxValue;
            }
        }

        queue.Enqueue((playerStartPoint.x, playerStartPoint.y, 0));
        visited[playerStartPoint.x, playerStartPoint.y] = 0;

        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();

            if (time > visited[x, y]) continue;

            if (board[x, y] == 'T')
            {
                sw.Write("YES");
                return;
            }


            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n || board[px, py] == 'I')
                    continue;

                int nextTime = time + 1;

                if (nextTime < visited[px, py] && nextTime < movePoint[px, py])
                {
                    queue.Enqueue((px, py, nextTime));
                    visited[px, py] = nextTime;
                }
            }
        }

        sw.Write("NO");
    }
}