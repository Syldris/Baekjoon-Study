#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        char[,] board = new char[n, n];
        bool[,] visited = new bool[n, n];
        int[,] visitedTime = new int[n, n];

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                board[x, y] = line[x];
                visitedTime[x, y] = int.MaxValue;
            }
        }

        int rank = 0;
        (int size, char c, int group)[,] tag = new (int, char, int)[n, n];
        int[] tx = new int[] { -1, 1, 0, 0 };
        int[] ty = new int[] { 0, 0, -1, 1 };

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (!visited[x, y])
                {
                    TagBFS(x, y);
                }
            }
        }

        // 멀티소스 다익스트라로 한번에 구하기.
        PriorityQueue<(int x, int y, int cost, char c), int> queue = new();

        // 시작할때 인접한땅은 사야함, 문자도 같이 저장.
        for (int y = 1; y < n; y++)
        {
            (int size, char c, int group) = tag[0, y];
            queue.Enqueue((0, y, size, c), size); // 왼쪽벽(시작점 제외)
            visitedTime[0, y] = size;
        }
        for (int x = 1; x < n - 1; x++)
        {
            (int size, char c, int group) = tag[x, n - 1];
            queue.Enqueue((x, n - 1, size, c), size); // 아래쪽벽(끝점 제외)
            visitedTime[x, n - 1] = size;
        }

        int[] dx = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        while (queue.Count > 0)
        {
            (int x, int y, int cost, char c) = queue.Dequeue();

            if (x == n - 1 || y == 0) // 오른쪽 벽이나 위쪽 벽에 닿으면 시작점과 끝점을 반으로 가르는 벽.
            {
                sw.Write(cost);
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if (px < 0 || py < 0 || px >= n || py >= n)
                    continue;

                if (board[px, py] == '.') continue; // 시작점 끝점은 사면 안됨.

                int curCost = cost;
                if (tag[x, y].group != tag[px, py].group) // 그룹이 다르면 다른판정. (문자가 같아도 다른 그룹일수있음)
                    curCost += tag[px, py].size;

                if (curCost < visitedTime[px, py])
                {
                    visitedTime[px, py] = curCost;
                    queue.Enqueue((px, py, curCost, board[px, py]), curCost);
                }
            }

        }


        // tag[사이즈, 문자]를 BFS로 채운다!
        void TagBFS(int startX, int startY)
        {
            List<(int x, int y)> list = new();
            Queue<(int x, int y)> queue = new();

            char c = board[startX, startY];

            visited[startX, startY] = true;
            queue.Enqueue((startX, startY));
            list.Add((startX, startY));

            while (queue.Count > 0)
            {
                (int x, int y) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int px = x + tx[i];
                    int py = y + ty[i];

                    if (px < 0 || py < 0 || px >= n || py >= n)
                        continue;

                    if (!visited[px, py] && board[px, py] == c)
                    {
                        visited[px, py] = true;
                        queue.Enqueue((px, py));
                        list.Add((px, py));
                    }
                }
            }

            rank++; // 그룹도 칠해두기
            foreach ((int x, int y) in list)
            {
                tag[x, y] = (list.Count, c, rank);
            }
        }
    }
}