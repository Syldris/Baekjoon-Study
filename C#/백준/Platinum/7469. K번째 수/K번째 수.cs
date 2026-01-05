#nullable disable
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[][] tree = new int[n * 4][];

        Build(1, 1, n);
        int[] sorted = tree[1];

        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            int cost = line[2];

            int start = 0, end = n - 1;

            while (start < end)
            {
                int mid = (start + end) / 2;
                int value = sorted[mid];

                int num = Query(1, 1, n, a, b, value);
                if (cost > num)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            sw.WriteLine(sorted[start]);
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
            Merge(tree[node * 2], tree[node * 2 + 1], tree[node]);
        }

        int Query(int node, int start, int end, int left, int right, int value)
        {
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                int indexStart = 0;
                int indexEnd = end - start + 1;

                while (indexStart < indexEnd)
                {
                    int indexMid = (indexStart + indexEnd) / 2;
                    if (value >= tree[node][indexMid])
                    {
                        indexStart = indexMid + 1;
                    }
                    else
                    {
                        indexEnd = indexMid;
                    }
                }

                return indexStart;
            }

            int mid = (start + end) / 2;
            return Query(node * 2, start, mid, left, right, value) + Query(node * 2 + 1, mid + 1, end, left, right, value);
        }

        void Merge(int[] left, int[] right, int[] sort)
        {
            int index = 0;
            int i = 0, j = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    sort[index++] = left[i++];
                }
                else
                {
                    sort[index++] = right[j++];
                }
            }

            if (i != left.Length)
            {
                while (i < left.Length)
                {
                    sort[index++] = left[i++];
                }
            }
            else
            {
                while (j < right.Length)
                {
                    sort[index++] = right[j++];
                }
            }
        }
    }
}