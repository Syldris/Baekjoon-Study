#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 65536));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput(), 65536));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());
        int[][] tree = new int[n * 4][];

        Build(1, 1, n);
        
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            sw.WriteLine(Query(1, 1, n, line[0], line[1], line[2]));
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
            Build(node * 2, start, mid);
            Build(node * 2 + 1, mid + 1, end);

            Merge(tree[node], tree[node * 2], tree[node * 2 + 1]);
        }

        int Query(int node, int start, int end, int left, int right, int value)
        {
            if (right < start || end < left)
            {
                return 0;
            }
            if (left <= start && end <= right)
            {
                int arrStart = 0;
                int arrEnd = tree[node].Length;

                while (arrStart < arrEnd)
                {
                    int arrMid = (arrStart + arrEnd) / 2;
                    if (value >= tree[node][arrMid])
                    {
                        arrStart = arrMid + 1;
                    }
                    else
                    {
                        arrEnd = arrMid;
                    }
                }
                return tree[node].Length - arrStart;
            }

            int mid = (start + end) / 2;

            return Query(node * 2, start, mid, left, right, value) + Query(node * 2 + 1, mid + 1, end, left, right, value);
        }

        void Merge(int[] result, int[] left, int[] right)
        {
            int index = 0;
            int i = 0, j = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    result[index++] = left[i++];
                }
                else
                {
                    result[index++] = right[j++];
                }
            }
            while (i < left.Length)
            {
                result[index++] = left[i++];
            }
            while (j < right.Length)
            {
                result[index++] = right[j++];
            }
        }
    }
}