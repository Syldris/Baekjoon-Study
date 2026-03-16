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

        int range = n * 2;
        List<int>[] graph = new List<int>[range + 1]; //2배로 확장시켜서 양수면 +n위치에 기록
        for (int i = 0; i <= range; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            line[0] = Setting(line[0]);
            line[1] = Setting(line[1]);

            // a V b 일때
            graph[Convert(line[0])].Add(line[1]); // not a = true면 b = true 여야한다
            graph[Convert(line[1])].Add(line[0]); // not b = true면 a = true 여야한다
        }

        int[] visited = new int[range + 1];
        bool[] inStack = new bool[range + 1];
        Stack<int> stack = new Stack<int>();

        int rank = 0;

        for (int i = 1; i <= range; i++)
        {
            if (visited[i] == 0 && !DFS(i))
            {
                sw.Write(0);
                return;
            }
        }
        sw.Write(1);

        bool DFS(int node)
        {
            visited[node] = ++rank;
            inStack[node] = true;
            stack.Push(node);

            int root = rank;

            foreach (var next in graph[node])
            {
                if (visited[next] == 0) // 방문 안한 노드만 
                {
                    if (!DFS(next)) // 자식이 실패하면 전달해줘야함
                    {
                        return false;
                    }
                }

                if (inStack[next]) // 인접한 노드중에서 아직 SCC 확정 안된 노드끼리만
                {
                    visited[node] = Math.Min(visited[next], visited[node]);
                }
            }

            if (visited[node] == root) // 이 노드에서 SCC확정. 더 올라가는 길이 없음
            {
                HashSet<int> hash = new();
                while (true)
                {
                    int pop = stack.Pop();
                    hash.Add(pop);
                    inStack[pop] = false;
                    /* 내 반대부호가 SCC에 있으면 모순임.
                       false => true 까진 모순이 아니지만 (안고르면 되니)
                       true => fasle 가 성립해버린다. 관계상 왼쪽이 true면 오른쪽은 true이도록 강제했으니 모순.
                      */
                    if (hash.Contains(Convert(pop)))
                    {
                        return false;
                    }

                    if (pop == node)
                        break;
                }
            }

            return true; // 논리관계상 모순이 없음
        }

        int Setting(int value)
        {
            if (value < 0)
                return value *= -1; // 음수는 1..n까지
            else
                return value += n; // 양수는 n+1.. 2n 까지
        }

        int Convert(int value) // 부호 변환
        {
            if (value > n) // 양수 => 음수
                return value - n;
            else
                return value + n; // 음수 => 양수
        }
    }
}