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


        Dictionary<int, int> dict = new();
        List<int> sorted = new();
        for (int i = 0; i < n; i++)
        {
            sorted.Add(query[i].start);
            sorted.Add(query[i].end);
        }

        sorted = sorted.Distinct().ToList();
        sorted.Sort();

        int rank = 0;
        foreach (int item in sorted)
        {
            dict[item] = ++rank; // 값 = 순서로 좌표압축
        }

        int[] tree = new int[rank * 4];
        int[] lazy = new int[rank * 4];

        for (int i = 0; i < n; i++)
        {
            (int start, int end) = query[i];

            int left = dict[start];
            int right = dict[end]; // 좌표압축으로 불러오기

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