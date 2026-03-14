#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int v = int.Parse(input[0]);
        int e = int.Parse(input[1]);

        List<int>[] graph = new List<int>[v + 1];
        for (int i = 1; i <= v; i++)
            graph[i] = new();

        for (int i = 0; i < e; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add(line[1]); // a => b 단방향 그래프
        }

        int[] visitedNode = new int[v + 1];
        bool[] inStack = new bool[v + 1];
        Stack<int> stack = new Stack<int>();

        int rank = 0;
        List<List<int>> result = new List<List<int>>();

        for (int i = 1; i <= v; i++)
        {
            if (visitedNode[i] == 0)
                DFS(i);
        }

        result.Sort((a, b) => a[0].CompareTo(b[0])); // 가장 작은 정점 순서로 scc 출력 (문제 요구)

        sw.WriteLine(result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            result[i].Add(-1); // 끝에 -1 추가 (문제 요구)
            sw.WriteLine(string.Join(' ', result[i]));
        }

        void DFS(int node)
        {
            visitedNode[node] = ++rank; // 방문체크와 스택삽입+기록
            stack.Push(node);
            inStack[node] = true;

            int root = rank;

            foreach (int next in graph[node])
            {
                if (visitedNode[next] == 0) // 방문안했으면 가보기
                    DFS(next);

                if (inStack[next]) // 이전에 방문했고 현재 스택에 있어 SCC로 묶이지 않았다면 전에 온쪽으로 기록을 갱신
                    visitedNode[node] = Math.Min(visitedNode[next], visitedNode[node]);
            }

            if (visitedNode[node] == root) // 방문 다하고왔을때 내가 루트이자 이전노드들의 조상임.
            {
                List<int> list = new List<int>(); // SCC 기록용 리스트.
                while (true)
                {
                    int pop = stack.Pop();
                    list.Add(pop);

                    inStack[pop] = false;

                    if (pop == node) // 본인까지만 뽑자.
                        break;
                }
                list.Sort(); // 속한 정점은 오름차순 정렬(문제 요구)
                result.Add(list);
            }
        }
    }
}