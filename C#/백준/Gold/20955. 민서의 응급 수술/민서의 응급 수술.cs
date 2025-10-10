#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] parent = new int[n+1];
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
        }

        int saver = 0;

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (!Union(a, b))
            {
                saver++;
            }
        }

        int result = saver;

        for (int i = 1; i <= n; i++)
        {
            if (parent[i] == i)
            {
                result++;
            }
        }

        sw.WriteLine(result - 1);
        int Find(int value)
        {
            if (parent[value] != value)
            {
                parent[value] = Find(parent[value]); 
            }
            return parent[value];
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