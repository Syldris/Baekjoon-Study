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
            string[] inputs = sr.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);
            int w = int.Parse(inputs[2]);
            List<(int from, int to, int cost)> graph = new List<(int from, int to, int cost)>();
            int[] distance = new int[n + 1];

            for (int i = 0; i < m; i++)
            {
                int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
                int from = line[0];
                int to = line[1];
                int cost = line[2];
                graph.Add((from, to, cost));
                graph.Add((to, from, cost));
            }
            for (int i = 0; i < w; i++)
            {
                int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
                int from = line[0];
                int to = line[1];
                int cost = line[2];
                graph.Add((from, to, -cost));
            }

            for (int i = 1; i <= n; i++)
            {
                foreach (var (from, to, cost) in graph)
                {
                    if (distance[from] + cost < distance[to])
                    {
                        distance[to] = distance[from] + cost;
                    }
                }
            }
            bool isCycle = false;
            for (int i = 1; i <= n; i++)
            {
                foreach (var (from, to, cost) in graph)
                {
                    if (distance[from] + cost < distance[to])
                    {
                        distance[to] = distance[from] + cost;
                        if(i == n)
                            isCycle = true;
                    }
                }
            }
            if (isCycle)
                sw.WriteLine("YES");
            else
                sw.WriteLine("NO");
        }
    }
}