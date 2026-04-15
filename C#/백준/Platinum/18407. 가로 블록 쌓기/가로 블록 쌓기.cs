#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        (int start, int end)[] query = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            query[i] = (line[1], line[0] + line[1] - 1); // 시작점, 시작점+길이-1
        }


        int[] sorted = new int[n * 2];
        for (int i = 0; i < n; i++)
        {
            sorted[i * 2] = query[i].start; // 0 2 4 6 8
            sorted[i * 2 + 1] = query[i].end; // 1 3 5 7 9
        }

        int[] order = new int[n * 2];
        for (int i = 0; i < n * 2; i++)
        {
            order[i] = i;
        }

        // 인덱스를 위의 배열을 통해 정렬. 
        // 1 1000 100 10 는 1 4 3 2 인덱스로 2번째 작은애는 4번째 인덱스다 등으로 표현. order = index

        Array.Sort(order, (a, b) => (sorted[a].CompareTo(sorted[b])));

        int rank = 0;

        int prevValue = sorted[order[0]]; // 0번째로 작은수 기록.
        sorted[order[0]] = ++rank;
        for (int i = 1; i < n * 2; i++)
        {
            int index = order[i]; // i번째로 작은수의 원래 인덱스.

            if (sorted[index] > prevValue) // i-1번째로 작은수보다 크다면
            {
                ++rank;
            }

            prevValue = sorted[index]; // i번째로 작은수 기록.
            sorted[index] = rank; // index에 순서 기록.
        }

        for (int i = 0; i < n; i++)
        {
            query[i] = (sorted[i * 2], sorted[i * 2 + 1]);
        }
        int[] tree = new int[rank * 4];
        int[] lazy = new int[rank * 4];

        for (int i = 0; i < n; i++)
        {
            (int left, int right) = query[i];

            int height = Query(1, 1, rank, left, right); // left ~ right 밑발판 최대높이구하기.

            Update(1, 1, rank, left, right, height + 1); // left ~ right는 이제 밑발판높이 +1만큼의 구역임.
        }

        sw.Write(Query(1, 1, rank, 1, rank));

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                tree[node] = value;
                lazy[node] = value;
                return;
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);

            tree[node] = Math.Max(tree[node << 1], tree[(node << 1) + 1]);
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            return Math.Max(Query(node << 1, start, mid, left, right), Query((node << 1) + 1, mid + 1, end, left, right));
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            tree[node << 1] = lazy[node];
            tree[(node << 1) + 1] = lazy[node];

            lazy[node << 1] = lazy[node];
            lazy[(node << 1) + 1] = lazy[node];

            lazy[node] = 0;
        }
    }
}