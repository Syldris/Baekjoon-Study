#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int[] money = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] parent = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            Union(a, b);
        }

        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            if (parent[i] == i)
            {
                result += money[i-1];
            }
        }

        sw.Write(k >= result ? result : "Oh no");

        int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                if (money[rootA - 1] <= money[rootB - 1])
                {
                    parent[rootB] = rootA;
                }
                else
                {
                    parent[rootA] = rootB;
                }
            }
        }
    }
}