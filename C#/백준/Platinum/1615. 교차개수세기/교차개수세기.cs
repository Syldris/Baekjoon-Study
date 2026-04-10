#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] tree = new int[n * 4];
        (int start, int end)[] edge = new (int, int)[m];
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            edge[i] = (line[0], line[1]);
        }

        Array.Sort(edge, (a, b) =>
        {
            if (a.start != b.start) // 시작점이 다르면 시작점 기준으로 오름차순
                return a.start.CompareTo(b.start);
            else                    // 같다면 끝점 기준으로 오름차순 (같은 시작점이여도 b+1 기준으로 세기에) 안겹치게 b 작은애부터
                return a.end.CompareTo(b.end);
        });

        long result = 0;

        for (int i = 0; i < m; i++)
        {
            (int a, int b) = edge[i];
            result += Query(1, 1, n, b + 1, n); // 나보다 이전에 나왔으면서 나보다 더 목표값이 큰놈이랑 겹친다.
            Update(1, 1, n, b);
        }

        sw.Write(result);

        void Update(int node, int start, int end, int index)
        {
            if (start == end)
            {
                tree[node]++;
                return;
            }

            int mid = (start + end) >> 1;
            if (index <= mid)
            {
                Update(node << 1, start, mid, index);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index);
            }

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) >> 1;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }
    }
}