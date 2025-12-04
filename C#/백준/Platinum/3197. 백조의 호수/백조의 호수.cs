#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[,] visited = new int[m, n];
        int[,] swanMove = new int[m, n];
        char[,] board = new char[m, n];

        (int x, int y) swan1 = (-1, -1);
        (int x, int y) swan2 = (-1, -1);

        Queue<(int x, int y, int day)> waterQueue = new();

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                char c = line[x];
                board[x, y] = c;
                swanMove[x, y] = int.MaxValue;

                if (c == 'L')
                {
                    if (swan1.x == -1 && swan1.y == -1)
                    {
                        swan1 = (x, y);
                    }
                    else
                    {
                        swan2 = (x, y);
                    }
                    waterQueue.Enqueue((x, y, 0));
                }
                else if (c == 'X')
                {
                    visited[x, y] = int.MaxValue;
                }
                else
                {
                    waterQueue.Enqueue((x, y, 0));
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        while (waterQueue.Count > 0)
        {
            (int x, int y, int day) = waterQueue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                {
                    continue;
                }

                if (board[px, py] == 'X' && day + 1 < visited[px, py])
                {
                    visited[px, py] = day + 1;
                    waterQueue.Enqueue((px, py, day + 1));
                }
            }
        }

        PriorityQueue<(int x, int y, int day), int> swanQueue = new();
        swanQueue.Enqueue((swan1.x, swan1.y, 0), 0);
        swanMove[swan1.x, swan1.y] = 0;

        while (swanQueue.Count > 0)
        {
            (int x, int y, int day) = swanQueue.Dequeue();
            if (x == swan2.x && y == swan2.y)
            {
                sw.Write(day);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                {
                    continue;
                }

                int curDay = Math.Max(day, visited[px, py]);

                if (curDay < swanMove[px, py])
                {
                    swanMove[px,py] = curDay;
                    swanQueue.Enqueue((px, py, curDay), curDay);
                }
            }
        }
    }
}