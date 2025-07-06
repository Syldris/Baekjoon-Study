#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (arr[0] == 0)
            {
                break;
            }
            int[] tree = new int[arr[0] * 4];

            Build(1, 1, arr[0]);
            sw.WriteLine(AreaQuery(1, arr[0]));

            int Build(int node, int start, int end)
            {
                if (start == end)
                {
                    return tree[node] = start;
                }

                int mid = (start + end) / 2;

                int left = Build(node * 2, start, mid);
                int right = Build(node * 2 + 1, mid + 1, end);

                if (arr[left] <= arr[right])
                {
                    return tree[node] = left;
                }
                else
                {
                    return tree[node] = right;
                }
            }

            int Query(int node, int start, int end, int left, int right)
            {
                if (start > right || end < left)
                {
                    return -1;
                }

                if (left <= start && end <= right)
                {
                    return tree[node];
                }

                int mid = (start + end) / 2;

                int leftQuery = Query(node * 2, start, mid, left, right);
                int rightQuery = Query(node * 2 + 1, mid + 1, end, left, right);

                if (leftQuery == -1)
                {
                    return rightQuery;
                }
                else if (rightQuery == -1)
                {
                    return leftQuery;
                }
                else
                {
                    if (arr[leftQuery] <= arr[rightQuery])
                        return leftQuery;
                    else
                        return rightQuery;
                }
            }

            long AreaQuery(int left, int right)
            {
                if (left > right)
                    return 0;

                int minIndex = Query(1, 1, arr[0], left, right);
                long area = (long)(right - left + 1) * arr[minIndex];

                long leftArea = AreaQuery(left, minIndex-1);
                long RightArea = AreaQuery(minIndex + 1, right);

                return Math.Max(area, Math.Max(leftArea, RightArea));
            }
        }
    }
}
