#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        bool[,] board = new bool[m, n];

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x] == 1 ? true : false;
            }
        }

        Queue<(int x, int y)> queue = new();
        queue.Enqueue((0, 0));
        board[0, 0] = false;

        int[] dx = new int[] { 1, 0 };
        int[] dy = new int[] { 0, 1 };

        while (queue.Count > 0)
        {
            (int x, int y) = queue.Dequeue();
            if (x == m - 1 && y == n - 1)
            {
                sw.Write("Yes");
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px >= m || py >= n)
                    continue;

                if (board[px, py])
                {
                    board[px, py] = false;
                    queue.Enqueue((px, py));
                }
            }
        }
        sw.Write("No");
    }
}