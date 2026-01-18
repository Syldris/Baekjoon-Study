#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0];
        int m = input[1];
        int k = input[2];

        char[,] board = new char[m, n];
        int[,] vitised = new int[m, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                vitised[x, y] = int.MaxValue;
                board[x, y] = line[x];
            }
        }
        int[] pos = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        (int x, int y) startPos = (pos[1] - 1, pos[0] - 1);
        (int x, int y) endPos = (pos[3] - 1, pos[2] - 1);

        Queue<(int x, int y, int cost)> queue = new();
        queue.Enqueue((startPos.x, startPos.y, 0));
        vitised[startPos.x, startPos.y] = 0;

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            (int x, int y, int cost) = queue.Dequeue();
            if (x == endPos.x && y == endPos.y)
            {
                sw.Write(cost);
                return;
            }

            for (int dir = 0; dir < 4; dir++)
            {
                int count = 0;
                for (int move = 1; move <= k; move++)
                {
                    int px = x + move * dx[dir];
                    int py = y + move * dy[dir];
                    int curcost = cost + 1;

                    if (px < 0 || py < 0 || px >= m || py >= n)
                        break;

                    if (board[px, py] == '#')
                        break;

                    if (curcost > vitised[px, py])
                        break;

                    if (curcost == vitised[px, py])
                    {
                        if (count >= 10)
                            break;
                        else
                        {
                            count++;
                            continue;
                        }
                    }

                    if (curcost < vitised[px, py])
                    {
                        vitised[px, py] = curcost;
                        queue.Enqueue((px, py, curcost));
                    }
                }
            }
        }
        sw.Write(-1);
    }
}