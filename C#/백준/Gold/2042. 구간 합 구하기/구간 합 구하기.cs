#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        long[] arr = new long[n + 1];
        long[] tree = new long[4 * n];
        for (int i = 1; i <= n; i++)
        {
            arr[i] = long.Parse(sr.ReadLine());
        }

        Build(1, 1, n);

        for (int i = 0; i < m+k; i++)
        {
            long[] line = sr.ReadLine().Split().Select(long.Parse).ToArray();
            if (line[0] == 1)
            {
                int index = (int)line[1];
                long value = line[2] - arr[index];
                arr[index] = line[2];
                Update(1, 1, n, index, value);
            }
            else
            {
                int left = (int)line[1];
                int right = (int)line[2];
                sw.WriteLine(Query(1, 1, n, left, right));
            }
        }

        long Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start];
            }
            int mid = (start + end) / 2;
            return tree[node] = Build(2 * node, start, mid) + Build(2 * node + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int index, long value)
        {
            if(index < start || index > end)
                return;

            tree[node] += value;
            if (start != end)
            {
                int mid = (start + end) / 2;

                Update(2 * node, start, mid, index, value);
                Update(2 * node + 1, mid + 1, end, index, value);
            }
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if(left > end || right < start)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            return Query(2 * node, start, mid, left, right) + Query(2 * node + 1, mid + 1, end, left, right);
        }
    }
}