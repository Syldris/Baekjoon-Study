#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        const int max = 100000;

        int[] tree = new int[max * 4];
        int[] lazy = new int[max * 4];

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int left = line[0];
            int right = line[1];

            sw.WriteLine(Query(left) + Query(right)); // left 와 right에 대해서 꽃이 피지않은 다른 식물과 교차점 갯수를 구하자.

            if (right - left > 1) // 차이가 1이하면 ex) 4 5 면 중간으로 들어갈 수평 선분이 없다.
                Update(left + 1, right - 1);
        }

        void Update(int left, int right, int node = 1, int start = 1, int end = max)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                if (start == end) // 점 쿼리이기에 리프노드만 갱신해도 된다.
                    tree[node] += 1;
                else
                    lazy[node] += 1; // 범위 노드에 대해선 lazy는 갱신 필수.
                return;
            }

            int mid = (start + end) >> 1;

            Push(node, start, end);

            Update(left, right, node << 1, start, mid);
            Update(left, right, (node << 1) + 1, mid + 1, end);

            // tree[node] = tree[node << 1] + tree[(node << 1) + 1]; 범위노드 원본값 필요X
        }

        int Query(int index, int node = 1, int start = 1, int end = max)
        {
            if (start == end)
            {
                int value = tree[node];
                tree[node] = 0; // 꽃이 피면 다시 꽃이 더 피지 않는다. 그러므로 전부 제거.
                return value;
            }

            int mid = (start + end) >> 1;
            Push(node, start, end);

            if (index <= mid)
                return Query(index, node << 1, start, mid);
            else
                return Query(index, (node << 1) + 1, mid + 1, end);
        }

        void Push(int node, int start, int end) // lazy정의 = 자식에게 아직 전파하지 않은값으로 둠.
        {
            if (lazy[node] == 0) return;

            tree[node << 1] += lazy[node];
            tree[(node << 1) + 1] += lazy[node];

            lazy[node << 1] += lazy[node];
            lazy[(node << 1) + 1] += lazy[node];

            lazy[node] = 0;
        }
    }
}