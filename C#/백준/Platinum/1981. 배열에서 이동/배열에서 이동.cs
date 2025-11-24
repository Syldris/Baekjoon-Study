#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[,] board = new int[n, n];
        int minValue = 200;
        int maxValue = 0;

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                board[x, y] = line[x];
                minValue = Math.Min(minValue, board[x, y]);
                maxValue = Math.Max(maxValue, board[x, y]);
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        bool[,] visited = new bool[n, n];
        int start = 0, end = maxValue - minValue;

        int result = end;

        while (start <= end)
        {
            int mid = (start + end) / 2;

            bool found = false;

            for (int left = minValue; left + mid <= maxValue; left++)
            {
                visitedClear();

                int right = left + mid;
                if (BFS(left, right))
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                result = mid;
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        sw.WriteLine(result);

        bool BFS(int left, int right)
        {
            if (board[0, 0] < left || board[0, 0] > right)
            {
                return false;
            }

            Queue<(int x, int y)> queue = new();
            queue.Enqueue((0, 0));
            visited[0,0] = true;

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();

                if (x + 1 == n && y + 1 == n)
                {
                    return true;
                }

                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];

                    if (px < 0 || py < 0 || px >= n || py >= n)
                    {
                        continue;
                    }
                    if (board[px,py] < left || board[px,py] > right || visited[px, py])
                    {
                        continue;
                    }

                    visited[px, py] = true;
                    queue.Enqueue((px, py));
                }
            }
            return false;
        }

        void visitedClear()
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    visited[x, y] = false;
                }
            }
        }
    }
}