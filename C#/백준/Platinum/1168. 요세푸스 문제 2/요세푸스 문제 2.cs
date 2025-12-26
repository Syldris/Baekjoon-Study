#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] tree = new int[n * 4];

        Build(1, 1, n);

        List<int> list = new List<int>();
        int num = n - 1;
        int order = k;
        int temp = Query(1, 1, n, order);

        list.Add(temp);
        Update(1, 1, n, temp);

        while (num > 0)
        {
            order = (order + k - 1) % num;
            if (order == 0)
            {
                order = num;
            }

            int value = Query(1, 1, n, order);
            list.Add(value);

            Update(1, 1, n, value);
            num--;
        }

        sw.Write($"<{String.Join(", ", list)}>");

        int Build(int node, int start, int end)
        {
            if (start == end)
            {
                return ++tree[node];
            }
            int mid = (start + end) / 2;

            return tree[node] =  Build(node * 2, start, mid) + Build(node * 2 + 1, mid + 1, end);
        }

        void Update(int node, int start, int end, int index)
        {
            if (start == end)
            {
                tree[node]--;
                return;
            }

            int mid = (start + end) / 2;

            if (mid >= index)
            {
                Update(node * 2, start, mid, index);
            }
            else
            {
                Update(node * 2 + 1, mid + 1, end, index);
            }

            tree[node] = tree[node * 2] + tree[node * 2 + 1];
        }

        int Query(int node, int start, int end, int index)
        {
            if (start == end)
            {
                return start;
            }

            int mid = (start + end) / 2;

            if (tree[node * 2] >= index)
            {
                return Query(node * 2, start, mid, index);
            }
            else
            {
                return Query(node * 2 + 1, mid + 1, end, index - tree[node * 2]);
            }
        }
    }
}