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
        const int mod = 5000000;

        int[,] tree = new int[max * 4, k];

        for (int i = 0; i < n; i++) // 순서를 고려해서 왼쪽부터 업데이트 해야함.
        {
            Update(1, 1, max, arr[i], 1, 0); // 길이 1 = 1임.
            for (int v = 1; v < k; v++)
            {
                // 본인보다 왼쪽에 있으면서 끝이 arr[i]보다 작으며, 길이-1개의 증가하는 수열 갯수
                int count = Query(1, 1, max, 1, arr[i] - 1, v - 1);

                //if (count == 0) break; // 길이 x개 증가하는 부분수열이 0개면 그 이후로도 쭉 0개이므로 끊기.

                Update(1, 1, max, arr[i], count, v); // count갯수만큼 본인에게 길이 v의 증가하는 수열로 이어붙임.
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