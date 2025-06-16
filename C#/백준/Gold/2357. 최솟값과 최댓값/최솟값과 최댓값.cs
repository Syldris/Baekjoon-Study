#nullable disable
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr = new int[n + 1];
        int[] mintree = new int[4 * n];
        int[] maxtree = new int[4 * n];

        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        Build(1, 1, n, false);
        Build(1, 1, n, true);

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            int minValue = Query(1, 1, n, a, b, false);
            int maxValue = Query(1, 1, n, a, b, true);
            sw.WriteLine($"{minValue} {maxValue}");
        }


        int Build(int node, int start, int end, bool isMax)
        {
            if (start == end)
            {
                if (isMax)
                    return maxtree[node] = arr[start];
                else
                    return mintree[node] = arr[start];
            }

            int mid = (start + end) / 2;

            if (isMax)
                return maxtree[node] = Math.Max(Build(node * 2, start, mid, isMax), Build(node * 2 + 1, mid + 1, end, isMax));
            else
                return mintree[node] = Math.Min(Build(node * 2, start, mid, isMax), Build(node * 2 + 1, mid + 1, end, isMax));
        }

        int Query(int node, int start, int end, int left, int right, bool isMax)
        {
            if(start > right || end < left)
                return isMax ? int.MinValue : int.MaxValue;

            if(start >= left && end <= right)
                return isMax ? maxtree[node] : mintree[node];

            int mid = (start + end) / 2;

            if (isMax)
                return Math.Max(Query(node * 2, start, mid, left, right, isMax), Query(node * 2 + 1, mid + 1, end, left, right, isMax));
            else
                return Math.Min(Query(node * 2, start, mid, left, right, isMax), Query(node * 2 + 1, mid + 1, end, left, right, isMax));
        }
    }
}