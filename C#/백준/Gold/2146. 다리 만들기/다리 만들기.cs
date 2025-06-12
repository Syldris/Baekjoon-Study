#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[,] board = new int[n, n];
        
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int y = 0; y < n; y++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < n; x++)
            {
                board[x, y] = input[x];
            }
        }

        PriorityQueue<(int x, int y, int tag, int cost), int> queue = new();

        int tagNum = 1;
        int[,] tagBoard = new int[n, n];
        List<(int x, int y, int tag)> taglist = new();

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (board[x,y] == 1 && tagBoard[x,y] == 0)
                {
                    tagBoard[x,y] = tagNum;
                    queue.Enqueue((x, y, tagNum, 0), 0);
                    taglist.Add((x, y, tagNum));
                    TagDFS(x, y, tagNum);
                    tagNum++;
                }
            }
        }
        int[,,] distance = new int[n, n, tagNum];
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                for (int tag = 0; tag < tagNum; tag++)
                {
                    distance[x,y,tag] = int.MaxValue; 
                }
            }
        }

        foreach ((int x, int y, int tag) in taglist)
        {
            distance[x, y, tag] = 0;
        }

        while (queue.Count > 0)
        {
            (int x, int y, int tag, int cost) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= n || py >= n)
                {
                    continue;
                }

                if (tag != tagBoard[px, py] && tagBoard[px,py] != 0)
                {
                    sw.Write(cost);
                    return;
                }

                int curcost = cost + 1;
                if (curcost < distance[px, py,tag] && board[px, py] == 0)
                {
                    distance[px, py, tag] = curcost;
                    queue.Enqueue((px, py, tag, curcost), curcost);
                }
            }
        }


        void TagDFS(int x, int y, int tag)
        {
            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= n || py >= n)
                {
                    continue;
                }
                if (tagBoard[px, py] == 0 && board[px,py] == 1)
                {
                    tagBoard[px, py] = tag;
                    taglist.Add((px, py, tag));
                    queue.Enqueue((px, py, tag, 0), 0);
                    TagDFS(px, py, tag);
                }
            }
        }
    }
}