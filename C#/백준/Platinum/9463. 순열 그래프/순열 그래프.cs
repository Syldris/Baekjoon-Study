#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        const int Range = 100000;
        int[] tree = new int[Range * 4];

        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            long result = 0;

            int[] arr1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] arr2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int[] order = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                int pos = arr1[i - 1];
                order[pos] = i; // 숫자에 대해 순서를기록해서 매핑. 
            }

            for (int i = 0; i < n; i++)
            {
                int index = order[arr2[i]];
                Update(1, 1, Range, index);
                result += Query(1, 1, Range, index + 1, Range);
            }

            sw.WriteLine(result);

            Array.Fill(tree, 0);
        }

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