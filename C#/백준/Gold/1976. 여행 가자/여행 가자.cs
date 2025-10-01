#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());
        int[] parent = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
        }

        for (int i = 0; i < n; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == 1)
                {
                    Union(i + 1, j + 1);
                }
            }
        }

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int first = Find(arr[0]);
        foreach (var item in arr)
        {
            if (first != Find(item))
            {
                sw.Write("NO");
                return;
            }
        }

        sw.Write("YES");
        int Find(int value)
        {
            if (parent[value] != value)
            {
                parent[value] = Find(parent[value]);
            }
            return parent[value];
        }

        void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                parent[rootA] = rootB;
            }
        }
    }
}
