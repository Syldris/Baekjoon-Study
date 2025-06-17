#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n + 1];
        string[] input = sr.ReadLine().Split();
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(input[i - 1]);
        }

        (int value, int index)[] tree = new (int, int)[n * 4];

        Build(1, 1, n);

        int m = int.Parse(sr.ReadLine());
        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            if (line[0] == 1)
            {
                Update(1, 1, n, line[1], line[2]);
            }
            else
            {
                sw.WriteLine(Query(1, 1, n, line[1], line[2]).index);
            }
        }


        (int value, int index) Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = (arr[start], start);
            }

            int mid = (start + end) / 2;
            (int value, int index) left = Build(node * 2, start, mid);
            (int value, int index) right = Build(node * 2 + 1, mid + 1, end);

            if (left.value == right.value)
            {
                return tree[node] = (left.value, Math.Min(left.index, right.index));
            }

            if (left.value <= right.value)
            {
                return tree[node] = (left.value, left.index);
            }
            else
            {
                return tree[node] = (right.value, right.index);
            }
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (index < start || end < index)
                return;

            if (start == end)
            {
                tree[node] = (value, index);
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node * 2, start, mid, index, value);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, end, index, value);
            }

            (int value, int index) left = tree[node * 2];
            (int value, int index) right = tree[node * 2 + 1];
            if (left.value == right.value)
            {
                tree[node] = (left.value, Math.Min(left.index, right.index));
            }
            else if (left.value <= right.value)
            {
                tree[node] = (left.value, left.index);
            }
            else
            {
                tree[node] = (right.value, right.index);
            }
        }

        (int value, int index) Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return (int.MaxValue, int.MaxValue);
            }

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            (int value, int index) leftQuery = Query(2 * node, start, mid, left, right);
            (int value, int index) rightQuery = Query(2 * node + 1, mid + 1, end, left, right);

            if (leftQuery.value == rightQuery.value)
            {
                return (leftQuery.value, Math.Min(leftQuery.index, rightQuery.index));
            }
            else if (leftQuery.value <= rightQuery.value)
            {
                return (leftQuery.value, leftQuery.index);
            }
            else
            {
                return (rightQuery.value, rightQuery.index);
            }
        }
    }
}