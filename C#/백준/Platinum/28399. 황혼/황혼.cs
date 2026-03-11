#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0];
        int m = input[1];
        int k = input[2];

        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];

            graph[a].Add((b, cost)); // a => b 단방향 도로만 있음
        }

        (int number, int order, int len)[] info = new (int, int, int)[n + 1]; // 각 도시는 1번만 나타나므로 도시에 정보번호와 순서만 기록해둬도 될듯.
        long[,] visited = new long[n + 1, 2]; // [도시, 경로 진행중인지 여부]
        for (int i = 1; i <= k; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int len = line[0];

            for (int j = 1; j <= len; j++)
            {
                info[line[j]] = (i, j, len); // [도시] = (정보번호, 순서, 길이)
            }
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                visited[i, j] = long.MaxValue;
            }
        }

        PriorityQueue<(int node, long cost, int infoNum, int onPath), long> queue = new(); // 노드, 비용, 금지경로번호, 금지경로로 진행중인지?

        int startOrder = info[1].order == 1 ? 1 : 0; // 시작할때 금지경로의 첫번째가 아니면 유효하지 않다.
        visited[1, startOrder] = 0;
        queue.Enqueue((1, 0, info[1].number, startOrder), 0);

        while (queue.Count > 0)
        {
            (int node, long cost, int infoNum, int onPath) = queue.Dequeue();

            if (cost > visited[node, onPath]) continue;

            foreach (var next in graph[node])
            {
                int nextInfoNum = info[next.node].number; // 금지 경로의 번호
                int nextOnPath = onPath; // 금지경로로 진행중인지?
                int nextInfoOrder = info[next.node].order; // 금지 경로 순서

                if (nextInfoNum != 0) // 0번은 금지경로에 속해있지 않으니 제외.
                {
                    // 금지경로로 진행중이며 금지경로번호가 같고 순서대로 이어진다면 금지경로 진행중.
                    if (onPath == 1 && infoNum == nextInfoNum && info[node].order + 1 == nextInfoOrder) 
                        nextOnPath = 1;

                    else if (infoNum != nextInfoNum && nextInfoOrder == 1) // 달라도 도착하는곳이 다른 금지경로의 시작부분이라면 진행시작.
                        nextOnPath = 1;

                    else // 다른 순서로 온 예외 경우 진행중이 아니다.
                        nextOnPath = 0;
                }
                else
                    nextOnPath = 0;

                if (nextInfoNum != 0 && nextOnPath == 1 && nextInfoOrder == info[next.node].len) // 금지경로에 진행중이면서 현재 순서가 마지막이면 갈수 없다.
                    continue;

                long nextCost = cost + next.cost;

                if (nextCost < visited[next.node, nextOnPath])
                {
                    visited[next.node, nextOnPath] = nextCost;
                    queue.Enqueue((next.node, nextCost, nextInfoNum, nextOnPath), nextCost);
                }
            }
        }

        for (int i = 1; i <= n; i++)
        {
            long result = long.MaxValue;
            for (int j = 0; j < 2; j++)
            {
                result = Math.Min(visited[i, j], result);
            }
            result = result == long.MaxValue ? -1 : result;

            sw.Write($"{result} ");
        }
    }
}