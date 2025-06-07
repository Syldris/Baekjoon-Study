#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            const int INF = 10000000;
            int[,] dist = new int[n+1, n+1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if(i == j)
                        dist[i, j] = 0;
                    else
                        dist [i, j] = INF;
                }
            }
            for (int i = 0; i < m; i++)
            {
                int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
                int from = line[0];
                int to = line[1];
                int cost = line[2];
                dist [from, to] = cost;
                dist [to, from] = cost;
            }

            int person = int.Parse(sr.ReadLine());
            int[] people = sr.ReadLine().Split().Select(int.Parse).ToArray();

            for (int v = 1; v <= n; v++)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (dist[i, v] + dist[v, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, v] + dist[v, j];
                        }
                    }
                }
            }

            int[] roomValue = new int[n+1];

            for (int i = 0; i < person; i++)
            {
                int curpeople = people[i];
                for (int j = 1; j <= n; j++)
                {
                    int value = dist[curpeople, j];
                    roomValue[j] += value;
                }
            }

            int minValue = roomValue.Skip(1).Min();
            for (int i = 1; i <= n; i++)
            {
                if (roomValue[i] == minValue)
                {
                    sw.WriteLine(i);
                    break;
                }
            }
        }
    }
}