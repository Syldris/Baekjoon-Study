#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());
        while (testcase-- > 0)
        {
            string[] input = sr.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                graph[line[0]].Add(line[1]);
            }

            int[] visited = new int[n];
            bool[] inStack = new bool[n];
            int[] scc = new int[n];

            int rank = 0;
            int sccGroup = 0;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                if (visited[i] == 0)
                    DFS(i);
            }

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

                    if (inStack[next]) // SCC 미확정 + 스택안에 있음
                    {
                        visited[node] = Math.Min(visited[node], visited[next]);
                    }
                }

                if (visited[node] == root)
                {
                    ++sccGroup;
                    while (true)
                    {
                        int pop = stack.Pop();

                        inStack[pop] = false;
                        scc[pop] = sccGroup;

                        if (pop == node)
                            break;
                    }
                }
            }

            int[] sccIndegree = new int[sccGroup + 1];
            for (int i = 0; i < n; i++)
            {
                foreach (var next in graph[i])
                {
                    if (scc[i] != scc[next]) // scc 그룹이 서로 다를때
                        sccIndegree[scc[next]]++; // next노드에 대해 scc의 진입차수를 +1
                }
            }

            bool find = true;
            // 진입차수 0인 scc그룹. 2개이상이면 불가. 2개 이상이면 a,b => c 같은 느낌인데 a-> b로 못감. 모든 노드 방문불가.
            int number = 0; 

            for (int i = 1; i < sccIndegree.Length; i++)
            {
                if (sccIndegree[i] == 0)
                {
                    if (number == 0)
                        number = i;
                    else
                    {
                        find = false; // 2개이상 이라는뜻.
                        break;
                    }
                }
            }

            if (find) // 진입차수 0인 scc 그룹이 1개. (0개는 scc상 존재하지 못하고 아예 1개 scc로 합쳐질듯함.)
            {
                for (int i = 0; i < n; i++)
                {
                    if (sccIndegree[scc[i]] == 0) // i노드에 대해 scc 진입차수가 0이면 모든 노드에 대해 갈수있을듯.
                    {
                        sw.WriteLine(i);
                    }
                }
            }
            else sw.WriteLine("Confused");

            if (testcase > 0)
            {
                sr.ReadLine();
            }
            sw.WriteLine();
        }
    }
}