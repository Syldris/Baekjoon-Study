#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] input = sr.ReadLine().Split();
        int[] arr = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(input[i - 1]);
        }

        int[] mintree = new int[n * 4];
        long[] sumtree = new long[n * 4];

        MinBuild(1, 1, n);
        SumBuild(1, 1, n);

        sw.Write(ScoreQuery(1, n));

        int MinBuild(int node, int start, int end)
        {
            if (start == end)
            {
                return mintree[node] = start;
            }

            int mid = (start + end) / 2;

            int leftNode = MinBuild(node * 2, start, mid);
            int rightNode = MinBuild(node * 2 + 1, mid + 1, end);

            return mintree[node] = arr[leftNode] < arr[rightNode] ? leftNode : rightNode;
        }

        long SumBuild(int node, int start, int end)
        {
            if (start == end)
            {
                return sumtree[node] = arr[start];
            }

            int mid = (start + end) / 2;

            return sumtree[node] = SumBuild(node * 2, start, mid) + SumBuild(node * 2 + 1, mid + 1, end);
        }

        int MinQuery(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return -1;
            }

            if (left <= start && end <= right)
            {
                return mintree[node];
            }

            int mid = (start + end) / 2;

            int leftNode = MinQuery(node * 2, start, mid, left, right);
            int rightNode = MinQuery(node * 2 + 1, mid + 1, end, left, right);

            if (leftNode == -1)
            {
                return rightNode;
            }
            else if (rightNode == -1)
            {
                return leftNode;
            }
            else
            {
                return arr[leftNode] < arr[rightNode] ? leftNode : rightNode;
            }
        }

        long SumQuery(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                return sumtree[node];
            }

            int mid = (start + end) / 2;
            return SumQuery(node * 2, start, mid, left, right) + SumQuery(node * 2 + 1, mid + 1, end, left, right);
        }

        long ScoreQuery(int start, int end)
        {
            if (start > end)
            {
                return 0;
            }
            if (start == end)
            {
                return (long)arr[start] * arr[start];
            }

            int minindex = MinQuery(1, 1, n, start, end);
            long sum = SumQuery(1, 1, n, start, end);

            long value = arr[minindex] * sum;

            if (start < minindex)
            {
                long leftValue = ScoreQuery(start, minindex - 1);
                value = Math.Max(value, leftValue);
            }
            if (minindex < end)
            {
                long rightValue = ScoreQuery(minindex + 1, end);
                value = Math.Max(value, rightValue);
            }
            return value;
        }
    }
}