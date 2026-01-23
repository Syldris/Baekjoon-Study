#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            if (n == 0 && m == 0)
            {
                break;
            }

            char[,] board = new char[m, n];
            int[,] visited = new int[m, n];
            int[,] count = new int[m, n];

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    board[x, y] = '.';
                    visited[x, y] = int.MaxValue;
                }
            }

            int g = int.Parse(sr.ReadLine());
            for (int i = 0; i < g; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int x = line[0];
                int y = line[1];
                board[x, y] = 'x';
            }

            int e = int.Parse(sr.ReadLine());
            (int x, int y, int time)[,] warp = new (int, int, int)[m, n];

            for (int i = 0; i < e; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int x1 = line[0];
                int y1 = line[1];
                int x2 = line[2];
                int y2 = line[3];
                int time = line[4];

                board[x1, y1] = 'w';
                warp[x1, y1] = (x2, y2, time);
            }

            bool never = false;
            bool impossible = true;
            int result = int.MaxValue;

            Queue<(int x, int y, int time)> queue = new Queue<(int, int, int)>();
            queue.Enqueue((0, 0, 0));
            visited[0, 0] = 0;

            int[] dx = new int[] { -1, 1, 0, 0 };
            int[] dy = new int[] { 0, 0, -1, 1 };

            while (queue.Count > 0)
            {
                (int x, int y, int time) = queue.Dequeue();

                if (never) break;

                if (visited[x, y] < time) continue;

                if (board[x, y] == 'w')
                {
                    (int wx, int wy, int warpTime) = warp[x, y];
                    int arrivalTime = time + warpTime;

                    if (arrivalTime < visited[wx, wy])
                    {
                        visited[wx, wy] = arrivalTime;

                        count[wx, wy]++;
                        if (count[wx, wy] > m * n)
                        {
                            never = true;
                            break;
                        }

                        queue.Enqueue((wx, wy, arrivalTime));
                    }
                    continue;
                }

                if (x == m - 1 && y == n - 1)
                {
                    result = Math.Min(result, time);
                    impossible = false;
                    continue;
                }

                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];

                    if (px < 0 || py < 0 || px >= m || py >= n)
                        continue;

                    if (board[px, py] == 'x')
                        continue;

                    int nextTime = time + 1;

                    if (board[px, py] == 'w')
                    {
                        (int wx, int wy, int warpTime) = warp[px, py];

                        if (nextTime < visited[px, py])
                        {
                            visited[px, py] = nextTime;

                            count[px, py]++;
                            if (count[px, py] > m * n)
                            {
                                never = true;
                                break;
                            }

                            int arrivalTime = nextTime + warpTime;

                            if (arrivalTime < visited[wx, wy])
                            {
                                visited[wx, wy] = arrivalTime;

                                count[wx, wy]++;
                                if (count[wx, wy] > m * n)
                                {
                                    never = true;
                                    break;
                                }

                                queue.Enqueue((wx, wy, arrivalTime));
                            }
                        }
                    }
                    else if (nextTime < visited[px, py])
                    {
                        visited[px, py] = nextTime;

                        count[px, py]++;
                        if (count[px, py] > m * n)
                        {
                            never = true;
                            break;
                        }

                        queue.Enqueue((px, py, nextTime));
                    }
                }
            }

            if (never)
                sw.WriteLine("Never");

            else if (impossible)
                sw.WriteLine("Impossible");

            else
                sw.WriteLine(result);
        }
    }
}