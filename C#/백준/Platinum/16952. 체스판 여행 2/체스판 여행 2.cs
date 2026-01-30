#nullable disable
public enum State
{
    knight,
    bishop,
    look
}

public readonly struct Node
{
    public readonly int x;
    public readonly int y;
    public readonly int value;
    public readonly int change;
    public readonly int time;
    public readonly State state;

    public Node(int x, int y, int value, int change, int time, State state)
    {
        this.x = x;
        this.y = y;
        this.value = value;
        this.change = change;
        this.time = time;
        this.state = state;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int startX = -1;
        int startY = -1;

        int max = n * n;
        int[,] board = new int[n, n];

        (int time, int change)[,,,] visited = new (int, int)[n, n, max + 1, 3];

        State basicState = State.knight;

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                int num = line[x];
                board[x, y] = num;

                if (num == 1)
                {
                    startX = x;
                    startY = y;
                }

                for (int v = 1; v <= max; v++)
                    for (int w = 0; w < 3; w++)
                        visited[x, y, v, w] = (int.MaxValue, 0);

            }
        }
        Queue<Node> queue = new();

        for (int i = 0; i < 3; i++)
        {
            State curState = basicState + i;
            Node node = new Node(startX, startY, 1, 0, 0, curState);

            queue.Enqueue(node);
            visited[startX, startY, 1, (int)curState] = (0, 0);
        }

        int minTime = int.MaxValue;
        int minChange = int.MaxValue;

        int[] kx = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] ky = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();

            int x = node.x;
            int y = node.y;
            int value = node.value;
            int change = node.change;
            int time = node.time;
            State state = node.state;

            if (time > minTime) break;

            if (value == max && board[x, y] == max)
            {
                minTime = time;
                minChange = Math.Min(change, minChange);
                continue;
            }

            if (state == State.knight) KnightMove(x, y, value, change, time);
            else if (state == State.bishop) BishopMove(x, y, value, change, time);
            else if (state == State.look) LookMove(x, y, value, change, time);

            for (int i = 0; i < 3; i++)
            {
                State changeState = basicState + i;
                if (changeState == state) continue;

                if (change < max)
                    Enqueue(x, y, value, change + 1, time, changeState, queue);
            }
        }

        sw.Write($"{minTime} {minChange}");

        void KnightMove(int x, int y, int value, int change, int time)
        {
            for (int i = 0; i < 8; i++)
            {
                int dx = x + kx[i];
                int dy = y + ky[i];

                if (dx < 0 || dy < 0 || dx >= n || dy >= n) continue;
                Enqueue(dx, dy, value, change, time, State.knight, queue);
            }
        }

        void BishopMove(int x, int y, int value, int change, int time)
        {
            int dx = x;
            int dy = y;
            void Reset() => (dx, dy) = (x, y);

            while (--dx >= 0 && --dy >= 0)
            {
                Enqueue(dx, dy, value, change, time, State.bishop, queue);
            }
            Reset();

            while (++dx < n && --dy >= 0)
            {
                Enqueue(dx, dy, value, change, time, State.bishop, queue);
            }
            Reset();

            while (--dx >= 0 && ++dy < n)
            {
                Enqueue(dx, dy, value, change, time, State.bishop, queue);
            }
            Reset();

            while (++dx < n && ++dy < n)
            {
                Enqueue(dx, dy, value, change, time, State.bishop, queue);
            }
        }

        void LookMove(int x, int y, int value, int change, int time)
        {
            for (int i = 0; i < n; i++)
            {
                Enqueue(i, y, value, change, time, State.look, queue);
            }

            for (int i = 0; i < n; i++)
            {
                Enqueue(x, i, value, change, time, State.look, queue);
            }
        }

        void Enqueue(int x, int y, int value, int change, int time, State state, Queue<Node> queue)
        {
            int nextTime = time + 1;
            int curValue = board[x, y] == value + 1 ? value + 1 : value;

            bool betterChange = nextTime == visited[x, y, curValue, (int)state].time && change < visited[x, y, curValue, (int)state].change;

            if (nextTime < visited[x, y, curValue, (int)state].time || betterChange)
            {
                visited[x, y, curValue, (int)state] = (nextTime, change);
                queue.Enqueue(new Node(x, y, curValue, change, nextTime, state));
            }
        }
    }
}