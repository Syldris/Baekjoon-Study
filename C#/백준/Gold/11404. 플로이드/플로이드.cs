using System;
using System.Numerics;
#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        const int INF = int.MaxValue / 2;

        int[,] dist = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if(i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = INF;
            }
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            dist[start, end] = Math.Min(dist[start,end],cost);
        }

        for(int v = 1; v <= n; v++)
        {
            for(int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, v] + dist[v, j]);
                }
            }
        }

        for(int i = 1; i <= n; i++)
        {
            for(int j = 1; j <= n; j++)
            {
                sw.Write(dist[i, j] == INF ? 0 : dist[i, j]);
                sw.Write(' ');
            }
            sw.WriteLine();
        }
    }
}