#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        const int max = 100000;
        int[,] tree = new int[max * 4, k];
        const int mod = 5000000;

        for (int i = 0; i < n; i++) // 순서를 생각하면서 해봐야함
        {
            int[] temp = new int[k];
            temp[0] = 1; // 길이 1은 항상 1개

            for (int v = 1; v < k; v++)
            {
                temp[v] = Query(1, 1, max, 1, arr[i] - 1, v - 1);
            }

            // 계산이 다 끝난 후에 트리에 한꺼번에 반영
            for (int v = 0; v < k; v++)
            {
                if (temp[v] > 0) Update(1, 1, max, arr[i], temp[v], v);
            }
        }

        sw.Write(Query(1, 1, max, 1, max, k - 1));

        void Update(int node, int start, int end, int index, int value, int k)
        {
            if (start == end)
            {
                tree[node, k] = (tree[node, k] + value) % mod;
                return;
            }

            int mid = (start + end) >> 1;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value, k);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value, k);
            }

            tree[node, k] = (tree[node << 1, k] + tree[(node << 1) + 1, k]) % mod;
        }

        int Query(int node, int start, int end, int left, int right, int k)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node, k];

            int mid = (start + end) >> 1;

            return (Query(node << 1, start, mid, left, right, k) + Query((node << 1) + 1, mid + 1, end, left, right, k)) % mod;
        }
    }
}