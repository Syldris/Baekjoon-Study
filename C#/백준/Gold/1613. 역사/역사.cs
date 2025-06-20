#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        bool[,] distance = new bool[n + 1, n + 1];

        for (int i = 0; i < k; i++)
        {
            string[] line = sr.ReadLine().Split();
            int from = int.Parse(line[0]);
            int to = int.Parse(line[1]);
            distance[from, to] = true;
        }

        for (int v = 1; v <= n; v++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (distance[i, v] && distance[v, j] && !distance[i, j])
                    {
                        distance[i, j] = true;
                    }
                }
            }
        }

        int m = int.Parse(sr.ReadLine());
        for (int i = 0; i < m; i++)
        {
            string[] inputs = sr.ReadLine().Split();
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            if (distance[a, b])
            {
                sw.WriteLine(-1);
            }
            else if (distance[b, a])
            {
                sw.WriteLine(1);
            }
            else
            {
                sw.WriteLine(0);
            }
        }
    }
}