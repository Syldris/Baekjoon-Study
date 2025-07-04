#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[,] distance = new int[n, n];
        
        for (int y = 0; y < n; y++)
        {
            string[] line = sr.ReadLine().Split();
            for (int x = 0; x < n; x++)
            {
                distance[x, y] = int.Parse(line[x]);
            }
        }

        int cost = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(i==j)
                    continue;
                bool connect = true;
                for (int v = 0; v < n; v++)
                {
                    if(v == i || v == j)
                        continue;

                    if (distance[i, j] > distance[i, v] + distance[v, j])
                    {
                        sw.Write(-1);
                        return;
                    }
                    if (distance[i, j] == distance[i, v] + distance[v, j])
                    {
                        connect = false;
                        break;
                    }
                }
                if (connect)
                    cost += distance[i, j];
            }
        }
        sw.Write(cost / 2);
    }
}
