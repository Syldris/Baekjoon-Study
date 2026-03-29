#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long[] sum = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            sum[i] = sum[i - 1] + arr[i - 1];
        }

        long[][] tree = new long[n * 4][];
        Build(1, 1, n);

        int q = int.Parse(sr.ReadLine());
        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = line[0];
            int b = line[1];

            /*전투구간의 2/3 까지만 지정가능하니 왼쪽 1/3 오른쪽 1/3은 고정으로 선택되어야한다
             * 나누는 지점을 k라고 했을때, 오른쪽-k 과 k-왼쪽 의 차를 구했을때 0에 가까운게 해다.
             왼쪽~K | K + 1~오른쪽으로 나누자. */

            int range = (b - a + 1) / 3; // 항상 쿼리는 3의 배수.

            // 중간 배열 값을 절반이 되게끔 최대한 자르자. 7(왼) 21(오) 라면 14의 절반인 7이 되게끔.
            long diff = (sum[b] - sum[a - 1]) / 2;

            // k는 왼쪽 그룹의 끝점. [a..k] | [k+1..b]
            // 고로 4 9 같을때 45| 67 | 89 일때 8은 포함되서는 안되지만. 5는 포함되어야한다. 45|6789 등으로 자르기 위해.

            sw.WriteLine(Query(1, 1, n, a + range - 1, b - range, diff, a, b)); // 범위를 제한해서 그중에서 쿼리를 날림. 왼쪽 -1설정 중요함.
        }

        void Build(int node, int start, int end) // 누적합 기반으로 오름차순 트리를 구성. 
        {
            tree[node] = new long[end - start + 1];
            if (start == end)
            {
                tree[node][0] = sum[start];
                return;
            }

            int mid = (start + end) >> 1;
            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            Merge(tree[node], tree[node << 1], tree[(node << 1) + 1]);
        }

        void Merge(long[] main, long[] left, long[] right)
        {
            int index = 0;
            int i = 0, j = 0;

            // 두 배열의 원소를 비교하며 병합정렬
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                    main[index++] = left[i++];
                else
                    main[index++] = right[j++];
            }

            // 비교하고 남은 쪽은 남김없이 채우자.
            while (i < left.Length)
            {
                main[index++] = left[i++];
            }

            while (j < right.Length)
            {
                main[index++] = right[j++];
            }
        }

        long Query(int node, int start, int end, int left, int right, long diff, int a, int b)
        {
            if (start > right || end < left)
                return long.MaxValue;

            if (left <= start && end <= right)
            {
                // sum[k] - sum[a-1] (왼쪽합)이 diff에 가장 가까운 k를 이진탐색으로 찾음.
                int low = 0;
                int high = end - start + 1;

                int offset = a - 1; // sum[offset] = a 이전까지 누적합.

                while (low < high)
                {
                    int half = (low + high) >> 1;

                    // 왼쪽합 <= 절반이면 올리자.
                    if (tree[node][half] - sum[offset] <= diff) // low가 diff 처음 초과하는 값으로 설계.
                    {
                        low = half + 1;
                    }
                    else
                    {
                        high = half;
                    }
                }

                // 이진탐색 끝. diff(절반)를 기준으로 low는 첫 초과 인덱스다.

                long totalValue = sum[b] - sum[a - 1]; // a~b 구간의 전체 합.
                long value = long.MaxValue;

                // 후보1. k로 자른 왼쪽합이 diff를 초과한 첫지점( 절반보다 살짝 큼)
                // low가 처음 초과하는 diff라 초과하는 값이 범위내에 없으면 length과 같을수도 있으니 예외처리.
                if (low < tree[node].Length)
                {
                    long leftvalue = tree[node][low] - sum[a - 1]; // 자를수 있는 범위중 k로 잘라서 남은 왼쪽 [l..k]
                    long rightValue = totalValue - leftvalue; // 남은 오른쪽 [k+1..b]

                    value = Math.Min(value, Math.Abs(rightValue - leftvalue)); // [l..k] vs [k+1..b] 차이 비교해서 더 적은쪽으로.
                }

                // 후보2. 왼쪽합이 diff 이하인 마지막 지점(절반과 같거나 작은 쪽)
                // 처음 초과하는 값보다 이전숫자인 diff의 이하 혹은 미만값과도 비교해본다.
                if (low > 0)
                {
                    long leftvalue = tree[node][low - 1] - sum[a - 1];
                    long rightValue = totalValue - leftvalue;

                    value = Math.Min(value, Math.Abs(rightValue - leftvalue));
                }

                return value;
            }

            int mid = (start + end) >> 1;

            long leftQuery = Query(node << 1, start, mid, left, right, diff, a, b);
            long rightQuery = Query((node << 1) + 1, mid + 1, end, left, right, diff, a, b);

            return Math.Min(leftQuery, rightQuery);
        }
    }
}