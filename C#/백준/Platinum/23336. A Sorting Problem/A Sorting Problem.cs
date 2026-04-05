#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int[] tree = new int[n * 4];

        long result = 0;

        for (int i = 0; i < n; i++)
        {
            result += Query(1, 1, n, arr[i] + 1, n); // 이전에 나온수중 본인보다 더 큰수라면 인접 교환 해야함. 
            Update(1, 1, n, arr[i]);
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
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) >> 1;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }
    }
}