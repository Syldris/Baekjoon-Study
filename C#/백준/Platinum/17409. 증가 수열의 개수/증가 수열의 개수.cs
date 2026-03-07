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
        int[,] tree = new int[n * 4, k]; // k = 길이 x 의 증가하는 수열로 DP기록.
        const int mod = 1000000007;

        for (int i = 0; i < n; i++)
        {
            Update(1, 1, n, arr[i], 1, 0); // 길이 1 은 = 1

            //for (int v = 2; v < k; v++)
            //{
            //    int count = Query(1, 1, n, 1, arr[i] - 1, v - 1);
            //    Update(1, 1, n, arr[i], count, v);
            //}

            for (int v = k - 1; v >= 1; v--) // 마치 배낭문제처럼 큰수=>작은수 순서로 해서 이전 값을 중복계산하지 못하게 하자.
            {
                int count = Query(1, 1, n, 1, arr[i] - 1, v - 1);
                Update(1, 1, n, arr[i], count, v);
            }
        }

        sw.Write(Query(1, 1, n, 1, n, k - 1));

        //for (int v = 1; v < k; v++)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        int value = Query(1, 1, n, 1, arr[i] - 1, v - 1); // 이전에 나왔던 수중에서 나보다 작은 수 = k-1길이의 이전 부분 증가 수열의 갯수.
        //        Update(1, 1, n, arr[i], value, v);
        //    }
        //}

        //sw.Write(Query(1, 1, n, 1, n, k - 1));

        void Update(int node, int start, int end, int index, int value, int k)
        {
            if (start == end)
            {
                tree[node, k] = (tree[node, k] + value) % mod;
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

            tree[node, k] = (tree[node << 1, k] + tree[(node << 1) + 1, k]) % mod;
        }

        int Query(int node, int start, int end, int left, int right, int k)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node, k];

            int mid = (start + end) / 2;

            return (Query(node << 1, start, mid, left, right, k) + Query((node << 1) + 1, mid + 1, end, left, right, k)) % mod;
        }
    }
}