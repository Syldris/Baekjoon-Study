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

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        List<int>[] graph = new List<int>[n + 1];

        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 2; i <= n; i++) // 1번은 조상 X
        {
            int parent = arr[i - 1];
            graph[parent].Add(i); // 조상 => 자식 순으로 연결
        }

        long[] tree1 = new long[n << 2]; // 상사 => 부하 방향 부하에게 범위업뎃.
        long[] lazy = new long[n << 2]; // 범위업뎃이므로 lazy
        long[] tree2 = new long[n << 2]; // 부하 => 상사 방향 상사시점에서. 범위쿼리

        bool isDown = true; // 부하방향  false시 상사방향

        (int start, int end)[] range = new (int, int)[n + 1];

        int rank = 0;
        DFS(1, -1);

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

            if (line[0] == 1)
            {
                (int start, int end) = range[line[1]];
                int value = line[2];

                if (isDown) // 부하 방향 (부하 전체 업데이트) 
                    RangeUpdate(1, 1, n, start, end, value);
                else        // 상사 방향 (본인 자신 업데이트)  
                    Update(1, 1, n, start, value);
            }
            else if (line[0] == 2)
            {
                (int start, int end) = range[line[1]];

                // 부하방향 칭찬은 부하에게 전하는 범위업뎃으로 받은 본인 1개의 값 확인.

                // 상사방향 칭찬은 자기 자신 범위내에서 부하가 얼마나 칭찬을 보냈는지 범위쿼리 확인.
                sw.WriteLine(Query(1, 1, n, start) + RangeQuery(1, 1, n, start, end));
            }
            else
            {
                isDown = !isDown; // 방향 변경
            }

        }

        void DFS(int node, int parent)
        {
            range[node].start = ++rank;

            foreach (var child in graph[node])
            {
                if (child == parent) continue;

                DFS(child, node);
            }
            range[node].end = rank;
        }

        void RangeUpdate(int node, int start, int end, int left, int right, long value) // 상사 => 부하 방향으로 부하범위에다가 범위 업데이트.
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                tree1[node] += (end - start + 1) * value;
                lazy[node] += value;
                return;
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            RangeUpdate(node << 1, start, mid, left, right, value);
            RangeUpdate((node << 1) + 1, mid + 1, end, left, right, value);

            tree1[node] = tree1[node << 1] + tree1[(node << 1) + 1];
        }

        long Query(int node, int start, int end, int index) // 상사 => 부하 방향에서 본인이 얼만큼 칭찬받았는지 자기자신 확인.
        {
            if (start == end)
            {
                return tree1[node];
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            if (index <= mid)
                return Query(node << 1, start, mid, index);
            else
                return Query((node << 1) + 1, mid + 1, end, index);
        }

        void Update(int node, int start, int end, int index, long value) // 부하 => 상사 방향. 부하에 기록해둬서 상사에서 범위쿼리로 확인.
        {
            if (start == end)
            {
                tree2[node] += value;
                return;
            }

            int mid = (start + end) >> 1;

            if (index <= mid)
                Update(node << 1, start, mid, index, value);
            else
                Update((node << 1) + 1, mid + 1, end, index, value);

            tree2[node] = tree2[node << 1] + tree2[(node << 1) + 1];
        }

        long RangeQuery(int node, int start, int end, int left, int right) // 부하 => 상사 방향 칭찬 상사에서 본인범위 쿼리로 부하가 얼만큼 칭찬했는지 확인.
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree2[node];

            int mid = (start + end) >> 1;

            return RangeQuery(node << 1, start, mid, left, right) + RangeQuery((node << 1) + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            int mid = (start + end) >> 1;

            long leftValue = (mid - start + 1) * lazy[node];
            long rightValue = (end - mid) * lazy[node];

            tree1[node << 1] += leftValue;
            tree1[(node << 1) + 1] += rightValue;

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}