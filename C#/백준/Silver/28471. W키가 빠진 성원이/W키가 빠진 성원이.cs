#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 21);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        char[,] board = new char[n, n];
        bool[,] visited = new bool[n, n];

        int startX = 0;
        int startY = 0;

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                char c = line[x];
                board[x, y] = c;
                if (c == 'F')
                {
                    (startX, startY) = (x, y);
                }
            }
        }

        int[] dx = new int[] { -1, -1, -1, 0, 1, 1, 1 };
        int[] dy = new int[] { -1, 0, 1, -1, -1, 0, 1 };

        Queue<(int x, int y)> queue = new();
        queue.Enqueue((startX, startY));
        visited[startX,startY] = true;


        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            for (int i = 0; i < dx.Length; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if(px < 0 || py < 0 || px >= n || py >= n)
                    continue;

                if (board[px, py] == '#')
                    continue;

                if (!visited[px, py])
                {
                    visited[px,py] = true;
                    queue.Enqueue((px, py));
                }
            }
        }

        int count = 0;

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (visited[x,y])
                    count++;
            }
        }
        sw.Write(count - 1);
    }
}