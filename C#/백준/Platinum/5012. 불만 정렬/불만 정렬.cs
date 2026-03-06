#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] tree = new int[n * 4];

        int[] left = new int[n]; // 나보다 왼쪽에 있으면서 큰수의 갯수
        int[] right = new int[n]; // 나보다 오른쪽에 있으면서 작은수의 갯수

        for (int i = 0; i < n; i++)
        {
            left[i] = Query(1, 1, n, arr[i] + 1, n); // 이전수중에서 arr[i]+1 ~ n 까지의 갯수 셈
            Update(1, 1, n, arr[i]);
        }

        Array.Clear(tree, 0, n * 4);

        for (int i = n - 1; i >= 0; i--) // 왼쪽 <- 오른쪽 순으로 훑으면서 1~arr[i]-1 로 나보다 작은수들의 갯수 셈.
        {
            right[i] = Query(1, 1, n, 1, arr[i] - 1);
            Update(1, 1, n, arr[i]);
        }

        long result = 0;

        for (int i = 0; i < n; i++)
        {
            result += (long)(left[i]) * right[i];
        }

        sw.Write(result);

        void Update(int node, int start, int end, int index)
        {
            if(start == end)
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
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }
    }
}