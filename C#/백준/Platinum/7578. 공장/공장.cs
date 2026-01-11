#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] arr2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        const int range = 1000000;

        int[] pos = new int[range + 1];

        for (int i = 0; i < arr.Length; i++)
        {
            int item = arr2[i];
            pos[item] = i + 1;
        }

        int[] tree = new int[range * 4];

        long result = 0;

        for (int i = 0; i < n; i++)
        {
            int item = arr[i];
            int index = pos[item];
            result += Query(1, 1, range, index, range);
            Update(1, 1, range, index);
        }

        sw.Write(result);

        void Update(int node, int start, int end, int index)
        {
            if (start == end)
            {
                tree[node]++;
                return;
            }

            int mid = (start + end) / 2;

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

            int mid = (start + end) / 2;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }
    }
}