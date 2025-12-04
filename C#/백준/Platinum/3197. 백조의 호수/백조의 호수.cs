#nullable disable
using static Program;

class Program
{

    public readonly struct Node
    {
        public readonly int x;
        public readonly int y;
        public readonly short day;

        public Node(int x, int y, short day)
        {
            this.x = x;
            this.y = y;
            this.day = day;
        }
    }

    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();

        short n = short.Parse(input[0]);
        short m = short.Parse(input[1]);

        short[,] visited = new short[m, n];
        short[,] swanMove = new short[m, n];
        char[,] board = new char[m, n];

        (int x, int y) swan1 = (-1, -1);
        (int x, int y) swan2 = (-1, -1);

        Queue<Node> waterQueue = new();

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                char c = line[x];
                board[x, y] = c;
                swanMove[x, y] = short.MaxValue;

                if (c == 'L')
                {
                    if (swan1.x == -1 && swan1.y == -1)
                    {
                        swan1 = (x, y);
                    }
                    else
                    {
                        swan2 = (x, y);
                    }
                    waterQueue.Enqueue(new Node(x, y, 0));
                }
                else if (c == 'X')
                {
                    visited[x, y] = short.MaxValue;
                }
                else
                {
                    waterQueue.Enqueue(new Node(x, y, 0));
                }
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        while (waterQueue.Count > 0)
        {
            Node node = waterQueue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int px = node.x + dx[i];
                int py = node.y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                {
                    continue;
                }
                short curDay = (short)(node.day + 1);
                if (board[px, py] == 'X' && curDay < visited[px, py])
                {
                    visited[px, py] = curDay;
                    waterQueue.Enqueue(new Node(px, py, curDay));
                }
            }
        }

        PriorityQueue<Node, short> swanQueue = new();
        swanQueue.Enqueue(new Node(swan1.x, swan1.y, 0), 0);
        swanMove[swan1.x, swan1.y] = 0;

        while (swanQueue.Count > 0)
        {
            Node node = swanQueue.Dequeue();
            if (node.x == swan2.x && node.y == swan2.y)
            {
                sw.Write(node.day);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                int px = node.x + dx[i];
                int py = node.y + dy[i];

                if (px < 0 || py < 0 || px >= m || py >= n)
                {
                    continue;
                }

                short curDay = node.day >= visited[px, py] ? node.day : visited[px, py];

                if (curDay < swanMove[px, py])
                {
                    swanMove[px,py] = curDay;
                    swanQueue.Enqueue(new Node(px, py, curDay), curDay);
                }
            }
        }
    }
}