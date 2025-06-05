#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int v = int.Parse(inputs[0]);
        int e = int.Parse(inputs[1]);
        int[,] dist = new int[v + 1, v + 1];
        const int INF = 10000000;
        for (int i = 1; i <= v; i++)
        {
            for (int j = 1; j <= v; j++)
            {
                dist[i, j] = INF;
            }
        }
        for (int i = 0; i < e; i++)
        {
            string[] line = sr.ReadLine().Split();
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            dist[start, end] = cost;
        }

        for (int k = 1; k <= v; k++)
        {
            for (int i = 1; i <= v; i++)
            {
                for (int j = 1; j <= v; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    } 
                }
            }
        }

        int minValue = int.MaxValue;
        for (int i = 1; i <= v; i++)
        {
            int value = dist[i, i];
            minValue = Math.Min(minValue, value);
        }
        sw.Write(minValue == INF ? -1 : minValue);
    }
}