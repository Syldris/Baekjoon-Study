#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        char[,] board = new char[m, n];
        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        int count = 0;
        int startbit = 1 << (board[0, 0] - 'A');
        Queue<(int x, int y, int value, int bit)> queue = new();
        queue.Enqueue((0, 0, 1, startbit));
        while (queue.Count > 0)
        {
            (int x, int y, int value, int bit) = queue.Dequeue();
            count = Math.Max(count, value);
            if (value == 26)
                break;
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= m || py >= n)
                {
                    continue;
                }
                int newbit = 1 << (board[px, py] - 'A');
                if((bit & newbit) == 0)
                {
                    queue.Enqueue((px, py, value + 1, bit | newbit));
                }
            }
        }

        sw.Write(count);
    }
}