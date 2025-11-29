#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        bool[,] dist = new bool[n + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            dist[a, b] = true;
        }

        for (int v = 1; v <= n; v++)
        {
            for (int i = 1; i <= n; i++)
            {
                if (v == i)
                    continue;
                for (int j = 1; j <= n; j++)
                {
                    if (v == j)
                        continue;

                    if (!dist[i, j] && dist[i, v] && dist[v, j])
                    {
                        dist[i, j] = true;
                    }
                    if (!dist[j, i] && dist[j, v] && dist[v, i])
                    {
                        dist[j, i] = true;
                    }
                }
            }
        }

        for (int i = 1; i <= n; i++)
        {
            int result = 0;
            for (int j = 1; j <= n; j++)
            {
                if (i == j)
                    continue;

                if (!dist[i, j] && !dist[j, i])
                {
                    result++;
                }
            }
            sw.WriteLine(result);
        }
    }
}