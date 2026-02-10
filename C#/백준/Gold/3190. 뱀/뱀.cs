#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 22);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int n = int.Parse(sr.ReadLine());
        int k = int.Parse(sr.ReadLine());

        int[,] board = new int[n, n];
        for (int i = 0; i < k; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int row = line[0] - 1;
            int col = line[1] - 1;
            board[col, row] = 2;
        }

        int l = int.Parse(sr.ReadLine());

        int time = 0;
        int dir = 0;
        int x = 0, y = 0;
        bool gameOver = false;

        int[] dx = new int[] { 1, 0, -1, 0 };
        int[] dy = new int[] { 0, 1, 0, -1 };

        Queue<(int x, int y)> queue = new();
        queue.Enqueue((0, 0));
        board[0, 0] = 1;

        for (int i = 0; i < l; i++)
        {
            string[] line = sr.ReadLine().Split();
            int rotationTime = int.Parse(line[0]);

            while (time < rotationTime)
            {
                time++;
                Move();
                if (gameOver)
                {
                    sw.Write(time);
                    return;
                }
            }

            if (line[1] == "D")
            {
                dir = (dir + 1) % 4;
            }
            else
            {
                dir--;
                if (dir < 0)
                    dir = 3;
            }
        }

        while (true)
        {
            time++;
            Move();
            if (gameOver)
            {
                sw.Write(time);
                return;
            }
        }

        void Move()
        {
            x = x + dx[dir];
            y = y + dy[dir];
            if (x < 0 || y < 0 || x >= n || y >= n || board[x, y] == 1)
            {
                gameOver = true;
                return;
            }

            if (board[x, y] != 2)
            {
                (int rx, int ry) = queue.Dequeue();
                board[rx, ry] = 0;
            }

            queue.Enqueue((x, y));
            board[x, y] = 1;
        }
    }
}