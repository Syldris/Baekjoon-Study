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

        bool[,] board = new bool[m, n];
        bool[,] visited = new bool[m, n];
        bool seat = false;

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                if (line[x] == 'o')
                {
                    board[x, y] = true;
                }
                else
                {
                    seat = true;
                }
            }
        }
        int index = 0;
        int[] dx = new int[8];
        int[] dy = new int[8];
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }
                dx[index] = x;
                dy[index] = y;
                index++;
            }
        }

        int result = 0;
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (!board[x, y])
                    continue;
                visited[x,y] = true;
                for (int i = 0; i < 8; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];

                    if (px < 0 || py < 0 || px >= m || py >= n)
                        continue;

                    if (board[px, py] && !visited[px, py])
                    {
                        result++;
                    }
                }
            }
        }

        if (seat)
        {
            int value = 0;
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    if (board[x, y])
                        continue;

                    int cur = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        int px = x + dx[i];
                        int py = y + dy[i];

                        if (px < 0 || py < 0 || px >= m || py >= n)
                            continue;

                        if (board[px, py])
                            cur++;
                    }
                    value = Math.Max(cur, value);
                }
            }
            sw.Write(result + value);
        }
        else
        {
            sw.Write(result);
        }
    }
}