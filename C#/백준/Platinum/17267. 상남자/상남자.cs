#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        string[] input2 = sr.ReadLine().Split();
        int leftMove = int.Parse(input2[0]);
        int rightMove = int.Parse(input2[1]);

        char[,] board = new char[m, n];
        int[,] visited = new int[m, n];

        int startX = -1;
        int startY = -1;

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                char c = line[x];
                board[x, y] = c;
                visited[x, y] = -1;

                if (c == '2')
                {
                    (startX, startY) = (x, y);
                }
            }
        }

        Queue<(int x, int y, int left, int right)> queue = new();

        queue.Enqueue((startX, startY, leftMove, rightMove));
        visited[startX, startY] = leftMove + rightMove;

        int[] dx = new int[] { -1, 1, 0, 0 };
        int[] dy = new int[] { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            (int x, int y, int left, int right) = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                int curLeft = left;
                int curRight = right;

                if (i == 0)
                    curLeft--;
                else if (i == 1)
                    curRight--;

                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (board[px, py] == '1')
                    continue;

                if (curLeft < 0 || curRight < 0)
                    continue;

                int curValue = curLeft + curRight;
                if (curValue > visited[px, py])
                {
                    visited[px, py] = curValue;
                    queue.Enqueue((px, py, curLeft, curRight));
                }
            }
        }

        int result = 0;

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                if (visited[x, y] != -1)
                    result++;
            }
        }

        sw.Write(result);
    }
}