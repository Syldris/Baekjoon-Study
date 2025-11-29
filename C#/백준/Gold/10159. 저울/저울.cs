#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        bool[,] heavy = new bool[n + 1, n + 1];
        bool[,] light = new bool[n + 1, n + 1];

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            heavy[a, b] = true;
            light[b, a] = true;
        }

        for (int v = 1; v <= n; v++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (!heavy[i, j] && heavy[i, v] && heavy[v, j])
                    {
                        heavy[i, j] = true;
                    }
                    if (!light[i, j] && light[i, v] && light[v, j])
                    {
                        light[i, j] = true;
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

                if (!heavy[i,j] && !light[i,j])
                {
                    result++;
                }
            }
            sw.WriteLine(result);
        }
    }
}