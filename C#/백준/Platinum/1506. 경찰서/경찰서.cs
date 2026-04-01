#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] cost = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new();

        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '1')
                    graph[i].Add(j); // i => j 경로가 있음.
            }
        }

        Stack<int> stack = new Stack<int>();
        bool[] inStack = new bool[n];
        int[] visited = new int[n];
        int rank = 0;

        int result = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] == 0)
                DFS(i);
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
                if (visited[next] == 0) // 진입하지 않은 노드만 방문하기 중복방문X
                    DFS(next);

                if (inStack[next]) // inStack이 활성화 되어있다면 SCC 미확정인 노드이다.
                {
                    visited[node] = Math.Min(visited[next], visited[node]); // 이전 진입시점으로 되돌아가는 우회로가있는지 Min으로 갱신하면서 체크.
                }
            }

            if (visited[node] == root) // 진입시점 이전으로 되돌아가는 우회로X 하나의 싸이클 완성.
            {
                int value = int.MaxValue;

                while (true)
                {
                    int pop = stack.Pop();

                    value = Math.Min(value, cost[pop]); // 한 싸이클내에서 가장 싼 지역에 경찰서 세우기.
                    inStack[pop] = false;

                    if (pop == node)
                        break;
                }

                result += value;
            }
        }
    }
}