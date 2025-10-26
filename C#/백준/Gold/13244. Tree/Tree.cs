#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int m = int.Parse(sr.ReadLine());

            int[] parent = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
            }

            bool tree = true;

            for (int i = 0; i < m; i++)
            {
                string[] input = sr.ReadLine().Split();

                if (!tree)
                {
                    continue;
                }

                int a = int.Parse(input[0]);
                int b = int.Parse(input[1]);

                tree = Union(a, b);
            }

            if (!tree)
            {
                sw.WriteLine("graph");
                continue;
            }

            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                if (parent[i] == i)
                {
                    result++;
                }
            }

            sw.WriteLine(result == 1 ? "tree" : "graph");

            int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }

            bool Union(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);

                if (rootA != rootB)
                {
                    parent[rootA] = rootB;
                    return true;
                }
                return false;
            }
        }
    }
}