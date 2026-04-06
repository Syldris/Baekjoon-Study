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

        long[] tree = new long[m * 4];
        long[] lazy = new long[m * 4];

        (int start, int end, int value)[] info = new (int, int, int)[m]; // 구역 시작점, 끝점, 시작 도토리 갯수
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            info[i] = (line[0], line[1], line[2]);
        }

        Build(1, 1, m);

        while (true)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] == 0)
                break;

            int left = line[1];
            int right = line[2];

            if (line[0] == 1)
            {
                if (left > right) // 한바퀴 빙도는 경우.
                {
                    sw.WriteLine(SolveQuery(left, n) + SolveQuery(1, right));
                }
                else
                {
                    sw.WriteLine(SolveQuery(left, right));
                }
            }
            else
            {
                int value = line[3];
                if (left > right) // 한바퀴 빙도는 경우.
                {
                    SolveUpdate(left, n, value);
                    SolveUpdate(1, right, value);
                }
                else
                {
                    SolveUpdate(left, right, value);
                }
            }
        }

        long SolveQuery(int left, int right)
        {
            int l = lowerBoundEnd(left) + 1; // 0-index => 1-index
            int r = UpperBoundStart(right); // -1 해주면 구간 마지막 이하까지로 알수있고 +1안더해주는걸로 대체.
            if (l > r) return 0;
            return Query(1, 1, m, l, r);
        }

        void SolveUpdate(int left, int right, int value)
        {
            int l = lowerBoundEnd(left) + 1; // 0-index => 1-index
            int r = UpperBoundStart(right); // -1 해주면 구간 마지막 이하까지로 알수있고 +1안더해주는걸로 대체.
            if (l > r) return;
            Update(1, 1, m, l, r, value);
        }

        int lowerBoundEnd(int target) // end >= 구역시작 인 첫번째 인덱스. 이 구간부터 시작이다. 
        {
            int start = 0, end = m;

            while (start < end)
            {
                int mid = (start + end) >> 1;

                if (info[mid].end < target) // mid가 target보다 작을때만 mid 버리고 오른쪽으로 이동
                {
                    start = mid + 1;
                }
                else // 같거나 크면 왼쪽으로 이동해봄.
                {
                    end = mid;
                }
            }

            return start;
        }

        int UpperBoundStart(int target) // start > 구역 끝인 첫번째 인덱스. -1해주면 초과-1로 이하로 잡을수있다.
        {
            int start = 0, end = m;

            while (start < end)
            {
                int mid = (start + end) >> 1;

                if (info[mid].start <= target) // mid가 target보다 작거나 같으면 mid 버리고 오른쪽으로 이동
                {
                    start = mid + 1;
                }
                else // 초과했을때만 왼쪽으로 이동해봄.
                {
                    end = mid;
                }
            }

            return start;
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = info[start - 1].value; // 1 => 0 index 및 구역마다 도토리 갯수 저장.
                return;
            }

            int mid = (start + end) >> 1;

            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        void Update(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                long range = (end - start + 1);

                tree[node] += range * value; // 총합 = 구간 길이 * 값
                lazy[node] += value; // 전파는 값만.
                return;
            }

            int mid = (start + end) >> 1;
            Push(node, start, end);

            Update(node << 1, start, mid, left, right, value);
            Update((node << 1) + 1, mid + 1, end, left, right, value);

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) >> 1;
            Push(node, start, end);

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }

        void Push(int node, int start, int end)
        {
            if (lazy[node] == 0) return;

            int mid = (start + end) >> 1;
            int leftRange = (mid - start + 1);
            int rightRange = (end - mid);

            tree[node << 1] += lazy[node] * leftRange;
            tree[(node << 1) + 1] += lazy[node] * rightRange;

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}