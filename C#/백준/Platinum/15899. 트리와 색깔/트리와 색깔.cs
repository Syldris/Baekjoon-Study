#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        const int MOD = 1000000007;

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int c = int.Parse(input[2]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[][] tree = new int[n * 4][];

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1])); // a => b
            graph[line[1]].Add((line[0])); // b => a
        }

        (int start, int end)[] range = new (int, int)[n + 1]; // 원본 노드 => 세그트리 인덱스로 접근
        int[] rankToNode = new int[n + 1]; // 세그트리 인덱스 => 원본 노드로 접근
        int rank = 0;
        DFS(1, -1);

        Build(1, 1, n);
        int result = 0;

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int left = range[line[0]].start; // 트리내에서의 연속된 인덱스로 시작, 끝점
            int right = range[line[0]].end;

            result = (result + Query(1, 1, n, left, right, line[1])) % MOD; // 기준점으로 갯수셈.
        }

        sw.Write(result);

        void DFS(int node, int parent)
        {
            range[node].start = ++rank; // 루트에서 시작을 1부터 체크
            rankToNode[rank] = node; // 역방향으로 rank => node로 기록해두면 세그트리 빌드에 쓸수있다.

            foreach (var child in graph[node])
            {
                if (child == parent)
                    continue;

                DFS(child, node);
            }
            range[node].end = rank;
        }

        void Build(int node, int start, int end)
        {
            tree[node] = new int[end - start + 1];
            if (start == end)
            {
                int pos = rankToNode[start]; //  세그트리인덱스에서 원본 위치가 뭐였는지 복원
                tree[node][0] = arr[pos - 1]; // 원본 위치를 통해 값 저장. pos = 1-index -> 0-index
                return;
            }

            int mid = (start + end) >> 1;

            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            Merge(tree[node], tree[node << 1], tree[(node << 1) + 1]);
        }

        int Query(int node, int start, int end, int left, int right, int c) // 범위 내에서 c 이하의 개수 이분탐색으로 세기.
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
            {
                int low = 0; // 0개 시작
                int high = end - start + 1; // 최대인경우 서브트리 전체갯수.
                while (low < high)
                {
                    int middle = (low + high) >> 1;
                    if (tree[node][middle] <= c) // 1 1 2 2 3 일때 c = 2 라면 4개다. 생각해서보면 c를 초과 해버리는 처음 순간만을 찾으면 된다. 3이니 인덱스 4로 4개.
                    {
                        low = middle + 1;
                    }
                    else
                    {
                        high = middle;
                    }
                }

                return low;
            }

            int mid = (start + end) >> 1;

            return Query(node << 1, start, mid, left, right, c) + Query((node << 1) + 1, mid + 1, end, left, right, c);
        }

        void Merge(int[] arr, int[] left, int[] right) // 병합정렬
        {
            int index = 0;
            int i = 0, j = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j]) // 작은순으로 채움
                    arr[index++] = left[i++];
                else
                    arr[index++] = right[j++];
            }

            while (i < left.Length)
            {
                arr[index++] = left[i++];
            }

            while (j < right.Length)
            {
                arr[index++] = right[j++];
            }
        }
    }
}