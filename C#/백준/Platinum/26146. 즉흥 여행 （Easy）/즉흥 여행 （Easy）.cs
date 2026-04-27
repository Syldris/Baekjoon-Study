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
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            graph[line[0]].Add(line[1]); // u => v 의 단방향 항공선만이 주어진다.
        }

        int rank = 0;
        int sccGroup = 0;
        int[] visited = new int[n + 1];
        bool[] inStack = new bool[n + 1];

        Stack<int> stack = new();
        
        for (int i = 1; i <= n; i++)
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

            foreach (var child in graph[node])
            {
                if (visited[child] == 0)
                    DFS(child);

                if (inStack[child]) // 아직 SCC 체크 안된 노드만 병합.
                {
                    visited[node] = Math.Min(visited[node], visited[child]);
                }
            }

            // DFS 상에서 진입 A=>B 방향이 있음.
            // B에서 이전 진입시점 A를 발견하면 A <=> B 양방향이므로 SCC 체크 가능.

            if (root == visited[node]) // 더이상 되돌아가는 길이없음.
            {
                sccGroup++;
                while (true)
                {
                    int pop = stack.Pop();

                    inStack[pop] = false;

                    if (pop == node)
                        break;
                }
            }
        }

        // Scc그룹이 2개이상이라면 scc끼리 양방향 방문이 아니라 
        // 한쪽scc만 일방통행 혹은 길이없음
        // 시작점을 어떻게 골라도 모든 나라를 방문하려면 1개의 싸이클이여야 함.
        sw.WriteLine(sccGroup <= 1 ? "Yes" : "No");
    }
}