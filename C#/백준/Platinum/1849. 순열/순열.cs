#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] result = new int[n];
        int[] tree = new int[n * 4];

        Build(1, 1, n);

        for (int i = 1; i <= n; i++)
        {
            int x = int.Parse(sr.ReadLine());
            KthUpdate(1, 1, n, x, i);
        }

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine(result[i]);
        }

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = 1; // 1로 채워서 몇개 차있는지 기록
                return;
            }

            int mid = (start + end) >> 1;

            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);
            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        void KthUpdate(int node, int start, int end, int order, int value) // order 순서에 맞는 빈공간에 Update
        {
            if (start == end)
            {
                tree[node] = 0; // 0으로 바꿔서 빈공간이 아님을 기록.
                result[start - 1] = value;
                return;
            }

            int mid = (start + end) >> 1;

            if (order >= tree[node << 1]) //남은 빈공간의 값보다 남은 순서가 크면 왼쪽노드 공간 다쓰고도 오른쪽으로 가야함
            {
                KthUpdate((node << 1) + 1, mid + 1, end, order - tree[node << 1], value); // 남은순서 - 왼쪽빈공간으로 빈공간 2개있으면 4번째에서 2번째로 낮추기.
            }
            else
            {
                KthUpdate(node << 1, start, mid, order, value);
            }

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }
    }
}