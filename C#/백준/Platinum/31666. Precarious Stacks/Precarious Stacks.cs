#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        (int start, int size)[] query = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            query[i] = (line[0], line[1]);
        }

        List<int> sorted = new List<int>();
        for (int i = 0; i < n; i++)
        {
            sorted.Add(query[i].start);
            sorted.Add(query[i].start + query[i].size - 1);
        }

        Dictionary<int, int> dict = new();
        sorted = sorted.Distinct().ToList();
        sorted.Sort();

        int rank = 0;
        for (int i = 0; i < sorted.Count; i++)
        {
            dict[sorted[i]] = ++rank; // 값 = 순서 매핑
        }

        long[] tree = new long[rank * 4];
        long[] lazy = new long[rank * 4];

        for (int i = 0; i < n; i++)
        {
            (int start, int size) = query[i];

            int left = dict[start];
            int right = dict[start + size - 1];

            long height = Query(1, 1, rank, left, right); // left ~ right 밑발판 최대높이구하기.

            Update(1, 1, rank, left, right, height + size); // left ~ right는 이제 밑발판높이 + 정사각형 높이 만큼의 발판이 생김.

            sw.WriteLine(Query(1, 1, rank, 1, rank));
        }

        void Update(int node, int start, int end, int left, int right, long value)
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

        long Query(int node, int start, int end, int left, int right)
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