#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        const int Range = 1000000;
        int[] tree = new int[Range * 4];

        long result = 0;

        for (int i = 0; i < n; i++)
        {
            result += Query(arr[i], Range);
            Update(arr[i]);
        }

        sw.Write(result);

        void Update(int index, int node = 1, int start = 1, int end = Range)
        {
            if (start == end)
            {
                tree[node]++;
                return;
            }

            int mid = (start + end) >> 1;
            if (index <= mid)
            {
                Update(index, node << 1, start, mid);
            }
            else
            {
                Update(index, (node << 1) + 1, mid + 1, end);
            }

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        int Query(int left, int right, int node = 1, int start = 1, int end = Range)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) >> 1;

            return Query(left, right, node << 1, start, mid) + Query(left, right, (node << 1) + 1, mid + 1, end);
        }
    }
}