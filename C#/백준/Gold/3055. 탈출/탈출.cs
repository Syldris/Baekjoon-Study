#nullable disable
using System.Collections;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs =sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        char[,] board = new char[m, n];
        int[,] watervisited = new int[m, n];
        int[,] visited = new int[m, n];
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                watervisited[x,y] = int.MaxValue;
                visited[x,y] = int.MaxValue;
            }
        }
        

        List<(int x, int y)> waterlist = new List<(int x, int y)>();

        (int x, int y) startPos = (0, 0);
        (int x, int y) endPos = (0, 0);

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                char c = line[x];
                board[x, y] = c;
                if(c == 'S')
                {
                    startPos = (x, y);
                    board[x, y] = '.';
                }
                if(c == 'D')
                {
                    endPos = (x, y);
                }
                if(c == '*')
                {
                    waterlist.Add((x, y));
                    watervisited[x, y] = 0;
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        Queue<(int x, int y, int time)> waterqueue = new();
        foreach (var water in waterlist)
        {
            waterqueue.Enqueue((water.x, water.y, 0));
        }
        while (waterqueue.Count > 0)
        {
            (int x, int y, int time) = waterqueue.Dequeue();
            time++;
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if(px < 0 || py < 0 || px >= m || py >=n)
                    continue;
                
                if(time < watervisited[px, py] && board[px,py] == '.')
                {
                    watervisited[px, py] = time;
                    waterqueue.Enqueue((px, py, time));
                }
            }
        }
        Queue<(int x, int y, int time)> queue = new();
        queue.Enqueue((startPos.x, startPos.y, 0));
        while (queue.Count > 0)
        {
            (int x, int y, int time) = queue.Dequeue();
            if (x == endPos.x && y == endPos.y)
            {
                sw.Write(time);
                return;
            }
            time++;
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= m || py >= n)
                    continue;

                if (time < visited[px, py] && time < watervisited[px,py] && board[px, py] == '.' || board[px, py] == 'D' )
                {
                    visited[px, py] = time;
                    queue.Enqueue((px, py, time));
                }
            }
        }
        sw.Write("KAKTUS");
    }
}