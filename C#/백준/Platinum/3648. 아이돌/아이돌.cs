#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        while (true)
        {
            string text = sr.ReadLine();
            if (text == null)
                break;

            string[] input = text.Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int range = n * 2;
            List<int>[] graph = new List<int>[range + 1];
            for (int i = 1; i <= range; i++)
                graph[i] = new();

            graph[1].Add(Convert(1)); // -1 => 1 루트를 만들어서 1이 true가 되게끔 강제.

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int a = Setting(line[0]);
                int b = Setting(line[1]);
                // 둘중 하나는 참이여야 하니
                // a,b 둘중 하나를 거짓으로 만들면 -a 일때 b여야만한다. -b일때 a여야만한다. 로 강제가능.

                graph[Convert(a)].Add(b);
                graph[Convert(b)].Add(a);
            }

            Stack<int> stack = new();
            bool[] inStack = new bool[range + 1]; // 스택 존재 여부. (포함시 SCC그룹으로 확정짓는중.)
            int[] visited = new int[range + 1]; // 방문시점
            int[] scc = new int[range + 1]; // 노드의 scc그룹을 가르킴.

            int rank = 0;
            int sccGroup = 0;

            for (int i = 1; i <= range; i++)
            {
                if (visited[i] == 0)
                    DFS(i);
            }

            bool find = true;

            for (int i = 1; i <= n; i++)
            {
                if (scc[i] == scc[i + n]) // -i 와 i 가 같은 scc그룹이면 모순.
                {
                    // 위에서부터 그래프를 만들때 a가 참이면 b도 참이여야 한다로 두었는데,
                    // i => -i 는 모순이니 반대로 -i로 삼아야 하는데 -i => i 또한 성립되게되어 모순이다.

                    find = false;
                    sw.WriteLine("no");
                    break;
                }
            }

            if (find)
                sw.WriteLine("yes");

            void DFS(int node)
            {
                visited[node] = ++rank;

                inStack[node] = true;
                stack.Push(node);

                int root = rank; // 진입시점의 랭크 기록.

                foreach (var next in graph[node])
                {
                    if (visited[next] == 0) // 미방문시 무조건 방문. 방문시에는 중복 방문X
                        DFS(next);

                    if (inStack[next]) // SCC그룹 미확정인 방문지점에 대해서만 갱신.
                    {
                        visited[node] = Math.Min(visited[node], visited[next]); // 가능하면 더 이전으로 되돌아가기.
                    }
                }

                if (visited[node] == root) // 그래프상에서 어디로 가도 진입시점 이전으로 되돌아가는 길이 없음.
                {
                    // stack.Peek ~ node 까지 1개의 scc그룹으로 확정.
                    ++sccGroup;
                    while (true)
                    {
                        int pop = stack.Pop();

                        inStack[pop] = false; // SCC 확정을 알려서 다른 scc그룹에 병합되지 않게끔 기록.
                        scc[pop] = sccGroup;

                        if (pop == node) // DFS상에서 그래프 탐색방법을 생각해보면 스택으로 자식~본인 까지만 딱 빼고 끊어주기 가능.
                            break;
                    }
                }
            }


            int Setting(int value)
            {
                if (value < 0)
                    return -value; // 음수는 1~n
                else
                    return value += n; // 양수는 n+1~2n
            }

            int Convert(int value)
            {
                if (value > n)
                    return value - n; // n초과하면 양수니 음수로 -n
                else
                    return value + n; // 반대는 +n 
            }
        }

        /* a일때 b여야만한다.
        1 2  | -1 2, 1 -2
        1 -2 | -1 -2, 1 2
        -1 2 | 1 2, -1 -2
        -1 -2 | 1 -2, -1 2
        2-SAT는 눈으로 봐야 편하다.
        1 => 2 => -1 싸이클이 강제되는구조로 모순발생. */
    }
}