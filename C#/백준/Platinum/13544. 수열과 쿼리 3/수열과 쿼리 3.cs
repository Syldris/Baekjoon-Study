#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        int[][] tree = new int[n * 4][];

        Build(1, 1, n);

        int answer = 0;
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0] ^ answer;
            int b = line[1] ^ answer;
            int c = line[2] ^ answer;

            answer = Query(1, 1, n, a, b, c);
            sw.WriteLine(answer);
        }

        void Build(int node, int start, int end)
        {
            tree[node] = new int[end - start + 1];
            if (start == end)
            {
                tree[node][0] = arr[start - 1];
                return;
            }

            int mid = (start + end) / 2;

            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            Marge(tree[node], tree[node << 1], tree[(node << 1) + 1]);
        }

        void Marge(int[] main, int[] left, int[] right)
        {
            int i = 0, j = 0;
            int index = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    main[index++] = left[i++];

                else
                    main[index++] = right[j++];
            }

            while (i < left.Length)
            {
                main[index++] = left[i++];
            }
            while (j < right.Length)
            {
                main[index++] = right[j++];
            }
        }

        int Query(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                int low = 0;
                int high = end - start + 1;

                while (low < high)
                {
                    int point = (low + high) / 2;

                    if (value >= tree[node][point])
                        low = point + 1;
                    else
                        high = point;
                }

                return (end - start + 1) - low;
            }

            int mid = (start + end) / 2;

            return Query(node << 1, start, mid, left, right, value) + Query((node << 1) + 1, mid + 1, end, left, right, value);
        }
    }
}