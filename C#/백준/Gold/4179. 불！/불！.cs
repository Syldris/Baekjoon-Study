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

        List<(int x, int y)> firelist = new List<(int x, int y)>();
        int[,] fireTime = new int[m, n];
        int[,] visited = new int[m, n];
        for (int y = 0; y < n; y++)
            for (int x = 0; x < m; x++)
            {
                fireTime[x, y] = int.MaxValue;
                visited[x, y] = int.MaxValue;
            }


        char[,] board = new char[m, n];
        (int x, int y) startPos = (0, 0);

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
                if (line[x] == 'F')
                {
                    firelist.Add((x, y));
                    fireTime[x, y] = 0;
                }
                if (line[x] == 'J')
                {
                    startPos = (x, y);
                    board[x, y] = '.';
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int x, int y, int sec)> firequeue = new Queue<(int, int, int)>();
        foreach (var fire in firelist)
        {
            firequeue.Enqueue((fire.x, fire.y, 0));
        }
        while (firequeue.Count > 0)
        {
            (int x, int y, int sec) = firequeue.Dequeue();
            sec++;
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (board[px, py] == '.' &&sec < fireTime[px, py])
                {
                    fireTime[px, py] = sec;
                    firequeue.Enqueue((px, py, sec));
                }
            }
        }

        Queue<(int x, int y, int sec)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((startPos.x, startPos.y, 0));
        visited[startPos.x, startPos.y] = 0;

        while (queue.Count > 0)
        {
            (int x, int y, int sec) = queue.Dequeue();
            sec++;
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                {
                    sw.Write(sec);
                    return;
                }

                if (board[px,py] == '.' && sec < visited[px,py] && sec < fireTime[px,py])
                {
                    visited[px, py] = sec;
                    queue.Enqueue((px, py, sec));
                }
            }
        }
        sw.Write("IMPOSSIBLE");
    }
}