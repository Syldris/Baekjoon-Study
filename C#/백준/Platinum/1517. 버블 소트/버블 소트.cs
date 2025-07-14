    #nullable disable
    using System;
    using System.Collections;
    using System.Numerics;
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int[] sorted = (int[])arr.Clone();
            Array.Sort(sorted);
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int rank = 0;

            foreach (int i in sorted)
            {
                if(!dict.ContainsKey(i))
                    dict[i] = rank++;
            }

            for(int i = 0; i < n; i++)
                arr[i] = dict[arr[i]];

            int[] tree = new int[n * 4];

            void Update(int node, int start, int end, int index)
            {
                if (index < start || index > end)
                    return;

                if (start == end)
                {
                    tree[node]++;
                    return;
                }

                int mid = (start + end) / 2;
                if (index <= mid)
                {
                    Update(node*2, start, mid, index);
                }
                else
                {
                    Update(node * 2 + 1, mid + 1, end, index);
                }
                tree[node] = tree[node * 2] + tree[node * 2 + 1];
            }

            int Query(int node, int start, int end, int left, int right)
            {
                if (right < start || end < left)
                {
                    return 0;
                }

                if (left <= start && end <= right)
                {
                    return tree[node];
                }

                int mid = (start + end) / 2;

                return Query(node * 2, start, mid, left, right) + Query(node * 2 + 1, mid + 1, end, left, right);
            }

            long result = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (arr[i] > 0)
                    result += Query(1, 0, n - 1, 0, arr[i] - 1);
                Update(1, 0, n - 1, arr[i]);
            }
            sw.Write(result);
        }
    }
