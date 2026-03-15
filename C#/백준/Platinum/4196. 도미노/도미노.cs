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

            bool[] sccGroupIndegree = new bool[sccNumber + 1]; // scc그룹내으로 진입해오는 도미노여부

            for (int node = 1; node <= n; node++)
            {
                foreach (var next in graph[node])
                {
                    if (scc[node] != scc[next]) // scc 그룹이 같으면 진입차수가 의미가 없다. 어딜 밀어도 같기때문.
                    {
                        sccGroupIndegree[scc[next]] = true; // SCC그룹이 다르면 뒤쪽 SCC는 전부 밀리니 안밀어도 됨
                    }
                }
            }

            int result = 0;

            for (int i = 1; i <= sccNumber; i++)
            {
                if (!sccGroupIndegree[i]) // 다른 SCC에서 scc그룹내로 난입하는 도미노가 있으면 안밀어도 되고, 없으면 반드시SCC내에서 1개 밀어야한다.
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
                    }
                    if (inStack[next])
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

                        scc[pop] = sccNumber; // SCC 그룹 매기기

                        if (pop == node)
                            break;
                    }
                }
            }
        }
    }
}