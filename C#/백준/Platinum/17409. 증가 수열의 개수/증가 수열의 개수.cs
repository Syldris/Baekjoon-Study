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
        int[][] tree = new int[n * 4][]; // k = 길이 x 의 증가하는 수열로 DP기록.
        for (int i = 0; i < n * 4; i++) // 가변배열로 2차원 배열 오버헤드 제거
            tree[i] = new int[k];

        const int mod = 1000000007;

        for (int i = 0; i < n; i++)
        {
            Update(1, 1, n, arr[i], 1, 0); // 길이 1 은 = 1

            for (int v = 1; v < k; v++) // 다시 생각해보니 이전길이를 참고해서 중복으로 업데이트한 다해도 값 탐색범위가 본인-1이라 정방향도 된다. v=2로 실수해서 안된것.
            {
                int count = Query(1, 1, n, 1, arr[i] - 1, v - 1);
                if (count == 0) break; // 길이 v-1의 증가 부분 수열이 없으면 v, v+1 v+2 또한 만들수 없다.
                Update(1, 1, n, arr[i], count, v);
            }
        }

        sw.Write(Query(1, 1, n, 1, n, k - 1));

        void Update(int node, int start, int end, int index, int value, int k)
        {
            if (start == end)
            {
                tree[node][k] = (tree[node][k] + value) % mod;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value, k);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value, k);
            }

            tree[node][k] = (tree[node << 1][k] + tree[(node << 1) + 1][k]) % mod;
        }

        int Query(int node, int start, int end, int left, int right, int k)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node][k];

            int mid = (start + end) / 2;

            return (Query(node << 1, start, mid, left, right, k) + Query((node << 1) + 1, mid + 1, end, left, right, k)) % mod;
        }
    }
}