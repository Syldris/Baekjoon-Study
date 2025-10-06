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

        string[] input2 = sr.ReadLine().Split();
        int k = int.Parse(input2[0]);
        int[] truth = new int[k];

        for (int i = 0; i < k; i++)
        {
            truth[i] = int.Parse(input2[i+1]);
        }

        int[] parent = new int[n+1];
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
        }

        int result = 0;
        int[][] save = new int[m][];
        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            save[i] = line;
            int v = line[0];
            for (int j = 2; j < line.Length; j++)
            {
                Union(line[j - 1], line[j]);
            }
        }
        
        for (int i = 0; i < k; i++)
        {
            truth[i] = Find(truth[i]);
        }

        for (int i = 0; i < m; i++)
        {
            bool add = true;
            for (int check = 1; check < save[i].Length; check++)
            {
                if (truth.Contains(Find(save[i][check])))
                {
                    add = false;
                    break;
                }
            }
            if (add)
                result++;
        }

        sw.Write(result);

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