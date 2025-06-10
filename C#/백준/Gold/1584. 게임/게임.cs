#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[,] board = new int[501, 501];
        int[,] distance = new int[501, 501];

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };
        for(int y  = 0; y <= 500; y++)
        {
            for (int x = 0; x <= 500; x++)
            {
                distance[x,y] = int.MaxValue;
            }
        }
        distance[0, 0] = 0;

        int dangerNum = int.Parse(sr.ReadLine());
        for (int i = 0; i < dangerNum; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int x1 = Math.Min(input[0], input[2]);
            int y1 = Math.Min(input[1], input[3]);
            int x2 = Math.Max(input[0], input[2]);
            int y2 = Math.Max(input[1], input[3]);

            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    board[x, y] = 1;
                }
            }
        }
        int deathNum = int.Parse(sr.ReadLine());
        for (int i = 0; i < deathNum; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int x1 = Math.Min(input[0], input[2]);
            int y1 = Math.Min(input[1], input[3]);
            int x2 = Math.Max(input[0], input[2]);
            int y2 = Math.Max(input[1], input[3]);

            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    board[x, y] = -1;
                }
            }
        }

        PriorityQueue<(int x, int y, int cost), int> queue = new();
        queue.Enqueue((0, 0, 0),0);
        while (queue.Count > 0)
        {
            (int x, int y, int cost) = queue.Dequeue();

            if (cost > distance[x,y])
                continue;
            if (x == 500 && y == 500)
            {
                sw.Write(cost);
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if(px < 0 || py < 0 || px > 500 | py > 500)
                    continue;

                if (board[px,py] == -1)
                    continue;
                int curcost = cost + board[px, py];
                if (curcost < distance[px, py])
                {
                    distance[px, py] = curcost;
                    queue.Enqueue((px, py, curcost), curcost);
                }
            }
        }

        sw.Write(-1);
    }
}