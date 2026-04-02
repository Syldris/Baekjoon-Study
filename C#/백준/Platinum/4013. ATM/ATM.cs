#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int a = line[0];
            int b = line[1];

            graph[a].Add(b); // 단방향 간선
        }

        int[] cost = new int[n];
        for (int i = 0; i < n; i++)
        {
            cost[i] = int.Parse(sr.ReadLine());
        }

        // scc 체크용 자료구조.
        Stack<int> stack = new Stack<int>();
        bool[] inStack = new bool[n + 1];
        int[] visited = new int[n + 1];

        int[] scc = new int[n + 1]; // 노드가 어떤 scc그룹인지 기록.
        int rank = 0;
        int sccRank = 0;

        List<int> sccGroupMoney = new(); // scc그룹내 돈 합산.
        sccGroupMoney.Add(0); // 1index로 맞추기.

        for (int i = 1; i <= n; i++)
        {
            if (visited[i] == 0)
                DFS(i);
        }

        HashSet<(int, int)> hash = new(); // from => to 형식
        List<int>[] sccGraph = new List<int>[sccRank + 1];
        for (int i = 1; i <= sccRank; i++)
            sccGraph[i] = new();

        int[] sccIndegree = new int[sccRank + 1];

        for (int i = 1; i <= n; i++)
        {
            foreach (var next in graph[i])
            {
                if (scc[i] == scc[next]) // 같은 scc 면 진입차수 증가x
                    continue;

                // 한 scc그룹에 대해서 다른 scc그룹에 대해 진입차수 1번만 증가시키기.
                if (!hash.Contains((scc[i], scc[next])))
                {
                    sccGraph[scc[i]].Add(scc[next]); // scc기준 i그룹 => next그룹 그래프 만들어두기.

                    sccIndegree[scc[next]]++; // 도착지의 scc그룹 진입차수 증가.
                    hash.Add((scc[i], scc[next]));
                }
            }
        }

        string[] input2 = sr.ReadLine().Split();
        int startPoint = int.Parse(input2[0]); // 시작점
        int p = int.Parse(input2[1]);

        int[] dp = new int[sccRank + 1];
        for (int i = 1; i <= sccRank; i++)
        {
            dp[i] = -1; // 시작점 제외하고 -1로 둠.
        }

        // 시작점의 scc그룹은 값을 들고 시작.
        int startSCC = scc[startPoint];
        dp[startSCC] = sccGroupMoney[startSCC];

        Queue<int> queue = new();

        for (int i = 1; i <= sccRank; i++)
        {
            if (sccIndegree[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            int curSCC = queue.Dequeue();

            foreach (var nextSCC in sccGraph[curSCC])
            {
                if (dp[curSCC] != -1) // 시작점과 연결된 부분만 코스트 갱신.
                {
                    // 도착지에서 얻는 최대돈 = `` vs 현재 출발지 + 도착지에서 얻는 돈.
                    dp[nextSCC] = Math.Max(dp[nextSCC], dp[curSCC] + sccGroupMoney[nextSCC]);
                }

                sccIndegree[nextSCC]--; // 진입차수는 시작점과 관계없이 감소시켜 차례대로 탐색.
                if (sccIndegree[nextSCC] == 0)
                    queue.Enqueue(nextSCC);
            }
        }

        // 레스토랑(도착점) 의 포인트들
        int[] endPoint = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int result = 0;
        for (int i = 0; i < p; i++)
        {
            int restSCC = scc[endPoint[i]]; // 도착지의 scc그룹.
            result = Math.Max(result, dp[restSCC]);
        }

        sw.Write(result);

        void DFS(int node)
        {
            visited[node] = ++rank;
            inStack[node] = true;
            stack.Push(node);

            int root = rank;

            foreach (var next in graph[node])
            {
                if (visited[next] == 0)
                    DFS(next);

                if (inStack[next]) // SCC 미확정 노드만 체크.
                {
                    visited[node] = Math.Min(visited[node], visited[next]);
                }
            }
            // DFS 그래프 정방향 탐색 => <= 자식노드에서 우회로 역방향
            // 양방향으로 싸이클 완성.

            if (visited[node] == root)
            {
                int value = 0;
                ++sccRank;
                while (true)
                {
                    int pop = stack.Pop();

                    inStack[pop] = false;
                    scc[pop] = sccRank; // 노드가 어떤 scc그룹인지 기록.
                    value += cost[pop - 1]; // cost는 0index니 조심.

                    if (pop == node)
                        break;
                }
                sccGroupMoney.Add(value);
            }
        }

    }
}