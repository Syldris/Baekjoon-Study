#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int range = m * 2; // 음수 1~n 양수 n+1~2n 각각 관리해야해서 1~2n까지 필요
        List<int>[] graph = new List<int>[range + 1];
        for (int i = 1; i <= range; i++)
            graph[i] = new();

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = Setting(line[0]);
            int b = Setting(line[1]);

            /* 2-SAT
               a || b 둘중 하나를 만족해야 한다.
               a = false 라면 b = true
               b = false 라면 a = true 
               관계로 강제 시킬수있다. 그래프로 싸이클을 구해 서로 강제되는 관계를 구하고
               1개의 변수에서 true && false가 둘다 강제된다면 모순임. 
            */
            graph[Convert(a)].Add(b);
            graph[Convert(b)].Add(a);
        }

        Stack<int> stack = new();
        int[] visited = new int[range + 1]; // 방문시점 기록
        bool[] inStack = new bool[range + 1]; // SCC미확정 + 방문상태면 Stack에 있다고 표시하고 SCC로 묶을 수 있음
        int[] scc = new int[range + 1];

        int rank = 0;
        int sccGroup = 0;
        for (int i = 1; i <= range; i++)
        {
            if (visited[i] == 0)
                DFS(i);
        }

        for (int i = 1; i <= m; i++)
        {
            if (scc[i] == scc[i + m]) // -x 와 x가 같은 scc 그룹이라면 x => -x 와 -x => x가 둘다 강제되서 모순.
            {
                sw.Write("OTL");
                return;
            }
        }

        sw.Write("^_^");

        void DFS(int node)
        {
            visited[node] = ++rank;
            inStack[node] = true;
            stack.Push(node);

            int root = rank; // root 미리 기록.
            foreach (var next in graph[node])
            {
                if (visited[next] == 0) // 미방문인 노드면 방문.
                    DFS(next);

                if (inStack[next]) // SCC 미확정인 노드에 대해서만
                {
                    // node next 중 이전 진입시점으로 되돌아가기
                    visited[node] = Math.Min(visited[node], visited[next]);
                }
            }

            if (visited[node] == root) // 이전시점으로 되돌아가지 못하는 경우에 싸이클로 묶기.
            {
                sccGroup++;
                while (true)
                {
                    int pop = stack.Pop();
                    scc[pop] = sccGroup; // 노드 scc 그룹 기록.
                    inStack[pop] = false; // scc 확정체크.

                    if (pop == node)
                        break;
                }
            }
        }

        int Setting(int x)
        {
            if (x < 0) // 시작이 음수면 1~n으로 설정.
                return -x;
            else       // 시작이 양수면 n+1~2n으로 설정.
                return x + m;
        }

        int Convert(int x) // 음수 양수 전환
        {
            if (x <= m) // 1~N 이면 음수이니 +n으로 양수로 만들어줌.
                return x + m;
            else       // N+1~2N이면 양수이니 -n으로 음수로 만들어줌.
                return x - m;
        }
    }
}