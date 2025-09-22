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

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] parent = new int[n+1];
        for (int i = 0; i <= n; i++)
        {
            parent[i] = i;
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int first = int.Parse(line[0]);
            int a = int.Parse(line[1]);
            int b = int.Parse(line[2]);

            if (first == 0)
            {
                Union(a, b);
            }
            else
            {
                sw.WriteLine(Find(a) == Find(b) ? "YES" : "NO");
            }
        }

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
