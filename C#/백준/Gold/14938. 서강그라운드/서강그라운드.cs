#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] inputs = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inputs[0];
        int m = inputs[1];
        int r = inputs[2];
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[,] dist = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = 10000000;
            }
        }

        for (int i = 0; i < r; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int start = input[0];
            int end = input[1];
            int cost = input[2];
            dist[start, end] = Math.Min(cost, dist[start, end]);
            dist[end, start] = Math.Min(cost, dist[end, start]);
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
                    }
                }
            }
        }

        int maxValue = 0;
        for (int i = 1; i <= n; i++)
        {
            int value = 0;
            for (int j = 1; j <= n; j++)
            {
                if (dist[i, j] <= m)
                    value += arr[j - 1];
            }
            maxValue = Math.Max(maxValue, value);
        }
        sw.Write(maxValue);
    }
}