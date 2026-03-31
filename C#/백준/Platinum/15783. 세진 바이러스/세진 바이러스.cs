#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add(line[1]); // a => b 단방향 간선
        }

        /* 일반 DAG에선 싸이클이 없음이 보장되지만 
         싸이클이 생길수도 있는 일반그래프에서의 DAG 진입차수 세는 방법도 있다. 
        SCC로 싸이클끼리 묶어서 "같은 싸이클끼리는 진입차수가 늘어나지않게" 
        세면서 각 싸이클마다의 진입차수를 세면 된다.*/

        Stack<int> stack = new();
        int[] visited = new int[n];
        bool[] inStack = new bool[n];
        int[] scc = new int[n];

        int rank = 0;
        int sccGroup = 0;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] == 0)
                DFS(i);
        }

        int[] sccIndegree = new int[sccGroup + 1];

        for (int i = 0; i < n; i++)
        {
            foreach (var next in graph[i])
            {
                if (scc[i] == scc[next]) // 같으면 진입차수 증가X
                    continue;

                sccIndegree[scc[next]]++; // i => next 일때 next의 scc그룹 진입차수 증가.
            }
        }

        int result = 0;
        for (int i = 1; i <= sccGroup; i++)
        {
            if (sccIndegree[i] == 0) // SCC 그룹의 진입차수가 0일때만 바이러스를 흘려보내도 전부 감염가능. 
                result++;
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

                if (inStack[next]) // SCC 미확정이면서 인접한 노드에 대해서 방문지점 갱신.
                {
                    visited[node] = Math.Min(visited[node], visited[next]);
                }
            }

            if (visited[node] == root) // 이 노드에서 진입시점 이전으로 돌아가는 길이없음.
            {
                // SCC 그룹 확정짓는 시점이다.
                ++sccGroup;

                while (true)
                {
                    int pop = stack.Pop();

                    inStack[pop] = false; // SCC 확정되면 다른 SCC에 병합되지 않게 분리.
                    scc[pop] = sccGroup;

                    if (pop == node)
                    {
                        break;
                    }
                }
            }
        }
    }
}