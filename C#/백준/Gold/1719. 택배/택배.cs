#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        const int INF = 100000000;
        int[,] dist = new int[n + 1, n + 1];
        int[,] prev = new int[n + 1, n + 1];
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
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int from = line[0];
            int to = line[1];
            int cost = line[2];
            dist[from, to] = cost;
            dist[to, from] = cost;

            prev[from, to] = to;
            prev[to, from] = from;
        }

        for (int v = 1; v <= n; v++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (dist[i, v] + dist[v, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, v] + dist[v, j];
                        prev[i, j] = prev[i, v];
                    }
                }
            }
        }

        for (int x = 1; x <= n; x++)
        {
            for (int y = 1; y <= n; y++)
            {
                sw.Write(prev[x, y] == 0 ? "- " : $"{prev[x, y]} " );
            }
            sw.WriteLine();
        }
    }
}