#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] parent = new int[1000001];
        int[] value = new int[1000001];
        for (int i = 1; i <= 1000000; i++)
        {
            parent[i] = i;
            value[i] = 1;
        }

        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split();
            if (input[0] == "I")
            {
                Union(int.Parse(input[1]), int.Parse(input[2]));
            }
            else
            {
                int x = int.Parse(input[1]);
                sw.WriteLine(value[Find(x)]);
            }
        }

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
                if (value[rootA] >= value[rootB])
                {
                    parent[rootB] = parent[rootA];
                    value[rootA] += value[rootB];
                }
                else
                {
                    parent[rootA] = parent[rootB];
                    value[rootB] += value[rootA];
                }
            }
        }
    }
}