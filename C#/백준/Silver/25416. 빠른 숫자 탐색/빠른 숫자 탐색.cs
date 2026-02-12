#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[,] board = new int[5, 5];
        bool[,] visited = new bool[5, 5];
        for (int y = 0; y < 5; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < 5; x++)
            {
                board[x, y] = line[x];
            }
        }

        string[] input = sr.ReadLine().Split();
        int startY = int.Parse(input[0]);
        int startX = int.Parse(input[1]);

        Queue<(int x, int y, int time)> queue = new();
        queue.Enqueue((startX, startY, 0));
        visited[startX, startY] = true;

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();

            if (board[x, y] == 1)
            {
                sw.Write(time);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= 5 || py >= 5)
                    continue;

                if (board[px, py] == -1 || visited[px, py])
                    continue;

                visited[px, py] = true;
                queue.Enqueue((px, py, time + 1));
            }
        }

        sw.Write(-1);
    }
}