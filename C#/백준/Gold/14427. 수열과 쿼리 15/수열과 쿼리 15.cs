#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] input = sr.ReadLine().Split();
        int[] arr = new int[n+1];
        for (int i = 1; i <= n; i++)
        {
            arr[i] = int.Parse(input[i-1]);   
        }

        int m = int.Parse(sr.ReadLine());

        int[] tree = new int[n * 4];

        Build(1, 1, n);
        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            if (line[0] == 1)
            {
                Update(1, 1, n, line[1], line[2]);
            }
            else
            {
                sw.WriteLine(tree[1]);
            }
        }


        int Build(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node] = start;
            }

            int mid = (start + end) / 2;

            int left = Build(node * 2, start, mid);
            int right = Build(node * 2 + 1, mid + 1, end);

            return tree[node] = arr[left] <= arr[right] ? left : right;
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start > index || end < index)
            {
                return;
            }

            if (start == end)
            {
                arr[index] = value;
                return;
            }

            int mid = (start + end) / 2;
            if (index <= mid)
                Update(node * 2, start, mid, index, value);
            else
                Update(node * 2 + 1, mid + 1, end, index, value);

            int left = tree[node * 2];
            int right = tree[node * 2 + 1];
            tree[node] = arr[left] <= arr[right] ? left : right;
        }
    }
}
