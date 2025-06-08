#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        char[,] board = new char[n, m];
        int[,,] distance = new int[n, m, 4];

        (int x, int y) startPos = (0, 0);
        (int x, int y) endPos = (0, 0);
        bool c = false;

        for (int y = 0; y < m; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                board[x, y] = line[x];
                for (int d = 0; d < 4; d++)
                    distance[x, y, d] = int.MaxValue;
                if (line[x] == 'C')
                {
                    if (c)
                        endPos = (x, y);
                    else
                        startPos = (x, y);

                    board[x, y] = '.';
                    c = true;
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        PriorityQueue<(int x, int y, int dir, int count), int> queue = new();
        for (int i = 0; i < 4; i++)
        {
            queue.Enqueue((startPos.x, startPos.y, i, 0), 0);
        }
        while (queue.Count > 0)
        {
            (int x, int y, int dir, int count) = queue.Dequeue();
            if (x == endPos.x && y == endPos.y)
            {
                sw.Write(count);
                return;
            }
            if (count > distance[x, y, dir])
                continue;
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= n || py >= m || board[px, py] == '*')
                    continue;

                int curCount = dir == i ? count : count + 1;
                if (curCount < distance[px, py, i])
                {
                    distance[px, py, i] = curCount;
                    queue.Enqueue((px, py, i, curCount), curCount);
                }
            }
        }
    }
}