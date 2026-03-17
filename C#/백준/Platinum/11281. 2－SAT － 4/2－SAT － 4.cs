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

        int range = n * 2; // 범위를 2배 늘려서 음수는 1~n, 양수는 n+1~2n 범위까지 설정.

        List<int>[] graph = new List<int>[range + 1];
        for (int i = 1; i <= range; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            Build(ref line[0]);
            Build(ref line[1]);

            /* 2-SAT의 절을 통해 a V b 에서 둘이 false일순 없는 조건이 핵심.
             * ㄱa -> b 로 ㄱa가 true일땐 b또한 true여야한다.
             * ㄱb -> a 로 ㄱb가 true일땐 a또한 true여야한다.
             * 로 명제 X->Y 로 X가 참일땐 Y도 참이여야하는 강제 관계를 간선으로 삼자.
            */
            graph[Convert(line[0])].Add(line[1]);
            graph[Convert(line[1])].Add(line[0]);
        }

        int[] visited = new int[range + 1]; // 해당 노드가 방문가능한 최소의 노드 지점
        bool[] inStack = new bool[range + 1];
        Stack<int> stack = new Stack<int>();

        int rank = 0; // DFS 상에서의 진입순서.
        int sccNum = 0; // scc그룹 번호.
        int[] scc = new int[range + 1]; // 해당노드가 어디 SCC에 속하는지?

        for (int i = 1; i <= range; i++)
        {
            if (visited[i] == 0)
            {
                DFS(i);
            }
        }

        int[] result = new int[n];

        for (int i = 1; i <= n; i++)
        {
            int a = scc[Convert(i)]; // i = true 일떄 SCC.
            int b = scc[i]; // i = false 일때의 SCC.

            if (a == b) // 둘이 같은 SCC 관계면 1-> -1 & -1 -> 1 명제가 생겨 모순.
            {
                sw.Write(0);
                return;
            }

            /*
             * 생각을 해보면. 서로 다른 SCC관계에있다는건 위상정렬이 성립함.
             * 2-SAT 관계식에서 모순이 생기지 않으려면
             * True -> False 명제가 생겨선 안됨. (이미 고른 상태임)
             * False -> True 명제는 애초에 고르지 않았으니 모순이 되지않음.
             * 한마디로 우변을 False로 두는게 모순없이 타당한데, 그래프상 우리가 관계를
             * b -> ㄱa 등으로 두었는데, SCC 넘버는 그래프상 깊이우선으로 안쪽부터 SCC를 확정지으므로
             * SCC 번호가 낮은게 우변, 즉 번호가 낮은쪽이 False여야한다.
             * 요약하자면 False(높은번호) -> True(낮은번호) 가 되게 간선을 만들자.
             */

            if (a > b) // 7(a) -> 2(b) 같은 경우인데.. b가 true여야함. b = false i 이므로 
            {
                result[i - 1] = 0; // i = false 
            }
            else // 4(b) -> 2(a) 같은 경우인데 낮은쪽이 우변임 애초에. a가 true 여야하므로.
            {
                result[i - 1] = 1; // i = true
            }
        }

        sw.WriteLine(1);
        sw.Write(string.Join(' ', result));

        void DFS(int node)
        {
            visited[node] = ++rank;
            inStack[node] = true; // 스택에 집어넣는다는건 SCC가 확정되지 않고 
            stack.Push(node); // 다른 노드를 찾아서 같은 싸이클상으로 묶이는지 체크중이라는것.

            int root = rank; // 미리 원본 진입순서를 기록해주자.

            foreach (var next in graph[node])
            {
                if (visited[next] == 0) // 탐색 안한 노드는 탐색
                    DFS(next);

                if (inStack[next]) // 아직 SCC가 확정되지 않은 노드만 함께 SCC로 묶어주자.
                    visited[node] = Math.Min(visited[next], visited[node]);
            }

            /* 이 노드에서 이전 탐색 노드쪽으로 돌아가는 싸이클이 없음.
               현재 탐색한 제일 깊은노드에서부터 여기까지 최대크기 SCC로 묶을수 있음 */
            if (visited[node] == root)
            {
                ++sccNum;
                while (true)
                {
                    int pop = stack.Pop();
                    inStack[pop] = false; // 스택에 들어있지않다고 표시해서 이미 SCC로 확정됐다고 알리자.

                    scc[pop] = sccNum; // 노드마다 어떤 scc그룹에 있는지 메모.

                    if (pop == node) // 현재 노드까지만 뽑고 SCC로 확정시키자.
                        break;
                }
            }
        }

        void Build(ref int value)
        {
            if (value < 0) // 음수면 해당하는 양수로 매핑.
                value *= -1;
            else
                value += n; // 양수면 해당하는 수의 +n 상태로 설정.
        }

        int Convert(int value)
        {
            if (value <= n) // 1~n 인 음수면 +n을 더해 양수로.
                return value + n;
            else
                return value - n; // -n을 통해 음수로.
        }

        /*
         *  1 v 1  * -1 => 1  // -1 일떄 1이다. 는 말이안되지만 단방향간선이니까 -1대신 1을 고르면 됨.
         *  -1 v -1  * 1 => -1 // 1일때 -1이다  1을골랐을때 -1이여야함..
         *  1 true면 1 =false고. 1 = false일떄 1 = true다. 
         *  말이안됨 모순.
         *  그래프상 V관계를 or체크할떄 앞쪽을 false 뒤쪽 true 강제시켰을때 강제관계를 성립했는데
         *  같은 숫자가 SCC, 즉 싸이클관계에있으면 -1 -> 1 -> -1 -> 1 같은 명제가 생겨 모순이다.
         */
    }
}