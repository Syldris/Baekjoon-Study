#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[,] board = new int[n, n];
        int[,] visited = new int[n, n];

        int[] parent = new int[k + 1];
        int[] size = new int[k + 1];
        for (int i = 1; i <= k; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        Queue<(int x, int y, int num, int year)> queue = new();

        int number = 0;
        int count = 1;

        for (int i = 0; i < k; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int x = line[0] - 1;
            int y = line[1] - 1;

            board[x, y] = ++number;
            visited[x, y] = number;
            queue.Enqueue((x, y, number, 1));
            Move(x, y);
        }

        if (count == k)
        {
            sw.Write(0);
            return;
        }

        while (queue.Count > 0)
        {
            (int x, int y, int num, int year) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= n || py >= n)
                    continue;

                if (Find(board[px, py]) == Find(num))
                    continue;

                if (board[px, py] == 0)
                {
                    board[px, py] = num;
                    queue.Enqueue((px, py, num, year + 1));
                }
                else
                {
                    Union(board[x, y], board[px, py]);
                }
                Move(px, py);

                if (count == k)
                {
                    sw.Write(year);
                    return;
                }
            }
        }

        void Move(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                int rx = x + dx[i];
                int ry = y + dy[i];

                if (rx < 0 || ry < 0 || rx >= n || ry >= n)
                    continue;

                if (Find(board[rx, ry]) == 0)
                    continue;

                if (Find(board[x, y]) != Find(board[rx, ry]))
                {
                    Union(board[x, y], board[rx, ry]);
                }
            }
        }

        int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                count++;
                if (size[rootA] >= size[rootB])
                {
                    parent[rootB] = rootA;
                    size[rootA] += size[rootB];
                    return;
                }
                else
                {
                    parent[rootA] = rootB;
                    size[rootB] += size[rootA];
                    return;
                }
            }
        }
    }
}