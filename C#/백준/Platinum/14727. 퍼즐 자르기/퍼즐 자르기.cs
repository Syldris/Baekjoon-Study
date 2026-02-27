#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        int[] tree = new int[n * 4];
        Build(1, 1, n);

        sw.Write(AreaQuery(1, n));

        int Build(int node, int start, int end)
        {
            if (start == end)
                return tree[node] = start - 1;

            int mid = (start + end) / 2;

            int leftNode = Build(node << 1, start, mid);
            int rightNode = Build((node << 1) + 1, mid + 1, end);

            return tree[node] = arr[leftNode] > arr[rightNode] ? rightNode : leftNode; // 인덱스로 저장하지만 비교기준은 arr값 기준.
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return -1;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            int leftQuery = Query(node << 1, start, mid, left, right);
            int rightQuery = Query((node << 1) + 1, mid + 1, end, left, right);

            if (leftQuery == -1) // 반대쪽 쿼리가 비어있으면 바로 반환
                return rightQuery;
            else if (rightQuery == -1)
                return leftQuery;

            else if (arr[leftQuery] > arr[rightQuery]) // 작은쪽으로 저장해놓자.
                return rightQuery;
            else
                return leftQuery;
        }

        long AreaQuery(int left, int right)
        {
            if (left > right) return 0;

            int index = Query(1, 1, n, left, right);

            long value = (long)(right - left + 1) * arr[index];

            long leftQuery = AreaQuery(left, index);
            long rightQuery = AreaQuery(index + 2, right);

            value = Math.Max(Math.Max(leftQuery, rightQuery), value);

            return value;
        }

    }
}