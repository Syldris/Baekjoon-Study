#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        char[,] board = new char[n, n];
        int[,] height = new int[n, n];
        bool[,] visited = new bool[n, n];
        int[] arr = new int[n * n];

        (int x, int y) startPos = (0, 0);
        int k = 0;

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                char c = line[x];
                board[x, y] = c;

                if (c == 'P')
                    startPos = (x, y);

                else if (c == 'K')
                    k++;
            }
        }

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                int v = line[x];
                height[x, y] = v;
                arr[y * n + x] = v;
            }
        }

        arr = arr.Distinct().ToArray();
        Array.Sort(arr);

        int len = arr.Length;
        int start = 0, end = 0;

        int result = int.MaxValue;
        while (start < len)
        {
            int low = arr[start];
            int high = arr[end];

            if (BFS(low, high))
            {
                int diff = arr[end] - arr[start];
                result = Math.Min(diff, result);

                if(start < end)
                    start++;
                else
                    break;
            }
            else
            {
                if(end < len - 1)
                    end++;
                else
                {
                    break;
                }
            }
            VisitedClear();
        }

        sw.Write(result);


        bool BFS(int min, int max)
        {
            Queue<(int x, int y)> queue = new();
            queue.Enqueue((startPos));

            if (height[startPos.x, startPos.y] < min || height[startPos.x, startPos.y] > max)
                return false;

            visited[startPos.x, startPos.y] = true;
            int value = 0;

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;

                        int px = x + dx;
                        int py = y + dy;

                        if(px < 0 || py < 0 || px >= n || py >= n)
                            continue;

                        if (height[px,py] < min || height[px,py] > max)
                            continue;

                        if (!visited[px, py])
                        {
                            if (board[px, py] == 'K')
                                value++;

                            visited[px,py] = true;
                            queue.Enqueue((px, py));
                        }
                    }
                }
            }

            if (value == k)
            {
                return true;
            }
            return false;
        }

        void VisitedClear()
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    visited[x, y] = false;
                }
            }
        }
    }
}