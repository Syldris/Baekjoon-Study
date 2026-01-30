#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        while (true)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int l = input[0];
            int n = input[1];
            int m = input[2];

            if (l == 0 && n == 0 && m == 0) break;

            char[,,] board = new char[m, n, l];
            int[,,] visited = new int[m, n, l];

            (int x, int y, int floor) start = (0, 0, 0);

            for (int i = 0; i < l; i++)
            {
                for (int y = 0; y < n; y++)
                {
                    string line = sr.ReadLine();
                    for (int x = 0; x < m; x++)
                    {
                        char c = line[x];
                        if (c == 'S')
                            start = (x, y, i);

                        board[x, y, i] = c;
                        visited[x, y, i] = int.MaxValue;
                    }
                }
                sr.ReadLine();
            }

            int[] dx = new int[] { -1, 1, 0, 0 };
            int[] dy = new int[] { 0, 0, -1, 1 };

            Queue<(int x, int y, int floor, int time)> queue = new();
            queue.Enqueue((start.x, start.y, start.floor, 0));
            visited[start.x, start.y, start.floor] = 0;

            bool find = false;

            while (queue.Count > 0)
            {
                (int x, int y, int floor, int time) = queue.Dequeue();
                if (board[x, y, floor] == 'E')
                {
                    find = true;
                    sw.WriteLine($"Escaped in {time} minute(s).");
                    break;
                }

                for (int i = -1; i <= 1; i += 2)
                {
                    int newFloor = floor + i;

                    if (newFloor < 0 || newFloor >= l)
                        continue;

                    int nextTime = time + 1;

                    if (board[x, y, newFloor] != '#' && nextTime < visited[x, y, newFloor])
                    {
                        visited[x, y, newFloor] = nextTime;
                        queue.Enqueue((x, y, newFloor, nextTime));
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];

                    if (px < 0 || py < 0 || px >= m || py >= n)
                        continue;

                    int nextTime = time + 1;

                    if (board[px, py, floor] != '#' && nextTime < visited[px, py, floor])
                    {
                        visited[px, py, floor] = nextTime;
                        queue.Enqueue((px, py, floor, nextTime));
                    }
                }
            }

            if (!find)
                sw.WriteLine("Trapped!");
        }
    }
}