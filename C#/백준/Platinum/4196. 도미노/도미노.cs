#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            List<int>[] graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                graph[line[0]].Add(line[1]); // a to b 단방향 
            }


            int[] visited = new int[n + 1];
            bool[] inStack = new bool[n + 1];
            Stack<int> stack = new Stack<int>();

            int rank = 0;
            int sccNumber = 0;
            int[] scc = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                if (visited[i] == 0)
                    DFS(i);
            }

            int[] indegree = new int[n + 1];
            int[] sccGroupMaxIndegree = new int[sccNumber]; // scc그룹안의 최대 진입차수 값

            for (int node = 1; node <= n; node++)
            {
                foreach (var next in graph[node])
                {
                    if (scc[node] != scc[next]) // scc 그룹이 다르다면
                    {
                        indegree[next]++;

                        sccGroupMaxIndegree[scc[next]] = Math.Max(sccGroupMaxIndegree[scc[next]], indegree[next]);
                    }
                }
            }

            int result = 0;

            for (int i = 0; i < sccNumber; i++)
            {
                if (sccGroupMaxIndegree[i] == 0)
                    result++;
            }

            sw.WriteLine(result);

            void DFS(int node)
            {
                visited[node] = ++rank;
                stack.Push(node);
                inStack[node] = true;

                int root = rank;

                foreach (int next in graph[node])
                {
                    if (visited[next] == 0)
                    {
                        DFS(next);
                        visited[node] = Math.Min(visited[next], visited[node]);
                    }
                    else if (inStack[next])
                    {
                        visited[node] = Math.Min(visited[next], visited[node]);
                    }
                }

                if (visited[node] == root) // 순회 탐색했는데 싸이클에서 나보다 더 이전으로 못감
                {
                    sccNumber++;
                    while (true)
                    {
                        int pop = stack.Pop();
                        inStack[pop] = false;

                        scc[pop] = sccNumber;

                        if (pop == node)
                            break;
                    }
                }
            }
        }
    }
}