#nullable disable
using System;
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
            int index = 0;
            (int root, int size)[] parent = new (int, int)[n * 2];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = (i, 1);
            }
            Dictionary<string, int> hash = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] line = sr.ReadLine().Split();
                string a = line[0];
                string b = line[1];

                if (!hash.ContainsKey(a))
                {
                    hash.Add(a,index++);
                }
                if (!hash.ContainsKey(b))
                {
                    hash.Add(b,index++);
                }

                sw.WriteLine(Union(hash[a], hash[b]));
            }

            int Find(int x)
            {
                if (parent[x].root != x)
                {
                    parent[x].root = Find(parent[x].root); 
                }
                return parent[x].root; 
            }

            int Union(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);
                if (rootA != rootB)
                {
                    parent[rootA].root = rootB;
                    parent[rootB].size += parent[rootA].size;
                }
                return parent[rootB].size;
            }

        }
    }
}