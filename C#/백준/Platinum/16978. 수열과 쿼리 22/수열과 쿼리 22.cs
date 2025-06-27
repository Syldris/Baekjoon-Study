#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        long[] arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
        long[] tree = new long[n * 4];

        
        int m = int.Parse(sr.ReadLine());

        Build(1, 1, n);
        List<(int index, int value)> updateList = new List<(int, int)>();
        List<(int updateCount, int left, int right, int order)> queryList = new List<(int, int, int, int)>();
        int queryCount = 0;

        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            if (line[0] == 1)
            {
                updateList.Add((line[1], line[2]));
            }
            else
            {
                queryList.Add((line[1], line[2], line[3], queryCount));
                queryCount++;
            }
        }

        queryList = queryList.OrderBy(x => x.updateCount).ToList();

        long[] answer = new long[queryCount];
        int count = 0;

        foreach ((int updateCount, int left, int right, int order) in queryList)
        {
            while (count < updateCount)
            {
                (int index, int value) = updateList[count];
                Update(1, 1, n, index, value);
                count++;
            }
            answer[order] = Query(1, 1, n, left, right);
        }



        for (int i = 0; i < queryCount; i++)
        {
            sw.WriteLine(answer[i]);
        }


        long Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = arr[start - 1];
            }

            int mid = (start + end) / 2;
            return tree[node] = Build(node * 2, start, mid) + Build(node * 2 + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int index, long value)
        {
            if(index < start || index > end)
                return;
            if (start == end)
            {
                tree[node] = value;
                return;
            }

            int mid = (start + end) / 2;
            if (index <= mid)
            {
                Update(node * 2, start, mid, index, value);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, end, index, value);
            }

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;
            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;

            return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);   
        }
    }
}
