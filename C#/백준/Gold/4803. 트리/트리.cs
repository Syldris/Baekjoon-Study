#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        int num = 0;
        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            if (n == 0 && m == 0)
            {
                return;
            }

            int[] parent = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
            }

            HashSet<int> cycle = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                string[] line = sr.ReadLine().Split();
                int a = int.Parse(line[0]);
                int b = int.Parse(line[1]);
                Union(a, b);
            }

            int tree = 0;
            for (int i = 1; i <= n; i++)
            {
                if (parent[i] == i && !cycle.Contains(i))
                {
                    tree++;
                }
            }

            if (tree == 0)
            {
                sw.WriteLine($"Case {++num}: No trees.");
            }
            else if (tree == 1)
            {
                sw.WriteLine($"Case {++num}: There is one tree.");
            }
            else
            {
                sw.WriteLine($"Case {++num}: A forest of {tree} trees.");
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
                    if (cycle.Contains(rootA) || cycle.Contains(rootB))
                    {
                        cycle.Add(rootB);
                    }
                }
                else
                {
                    cycle.Add(rootB);
                }
            }
        }
    }
}